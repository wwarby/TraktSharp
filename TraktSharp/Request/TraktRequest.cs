using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.EventArgs;
using TraktSharp.Exceptions;
using TraktSharp.Helpers;
using TraktSharp.Serialization;
using TraktSharp.Structs;

namespace TraktSharp.Request {

	internal abstract class TraktRequest<TResponse, TRequestBody> : ITraktRequest<TResponse> where TRequestBody : class {

		public event BeforeRequestEventHandler BeforeRequest;
		public event AfterRequestEventHandler AfterRequest;

		private readonly TraktClient _client;

		protected TraktRequest(TraktClient client) {
			_client = client;
			Pagination = new TraktPaginationOptions();
		}

		internal TraktExtendedOption Extended { get; set; }

		internal TraktPaginationOptions Pagination { get; set; }

		private bool _authenticate;

		internal bool Authenticate {
			get {
				if (_client.Configuration.ForceAuthentication && AuthenticationRequirement != TraktAuthenticationRequirement.Forbidden) { return true; }
				if (AuthenticationRequirement == TraktAuthenticationRequirement.Required) { return true; }
				if (AuthenticationRequirement == TraktAuthenticationRequirement.Forbidden) { return false; }
				return _authenticate;
			}
			set {
				if (!value && AuthenticationRequirement == TraktAuthenticationRequirement.Required) { throw new InvalidOperationException("This request type requires authentication"); }
				if (!value && AuthenticationRequirement == TraktAuthenticationRequirement.Forbidden) { throw new InvalidOperationException("This request type does not allow authentication"); }
				_authenticate = value;
			}
		}

		protected abstract HttpMethod Method { get; }

		protected abstract string PathTemplate { get; }

		protected abstract TraktAuthenticationRequirement AuthenticationRequirement { get; }

		protected virtual bool SupportsPagination { get { return false; } }

		protected virtual void ValidateParameters() { }

		protected virtual IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) { return pathParameters; }

		private string Path {
			get {
				return GetPathParameters(new Dictionary<string, string>())
					.Aggregate(PathTemplate.ToLower(), (current, parameter) => current.Replace("{" + parameter.Key.ToLower() + "}", parameter.Value.ToLower()))
					.TrimEnd(new[] { '/' });
			}
		}

		protected virtual IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			if (Extended != TraktExtendedOption.Unspecified) {
				queryStringParameters["extended"] = TraktEnumHelper.GetDescription(Extended);
			}
			if (SupportsPagination) {
				if (Pagination.Page != null) { queryStringParameters["page"] = Pagination.Page.ToString(); }
				if (Pagination.Limit != null) { queryStringParameters["limit"] = Pagination.Limit.ToString(); }
			}
			return queryStringParameters;
		}

		private string QueryString {
			get {
				using (var content = new FormUrlEncodedContent(GetQueryStringParameters(new Dictionary<string, string>()))) {
					var ret = content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(ret)) { ret = string.Format("?{0}", ret); }
					return ret;
				}
			}
		}

		internal string Url { get { return string.Format("{0}{1}{2}", _client.Configuration.BaseUrl, Path, QueryString); } }

		internal TRequestBody RequestBody { get; set; }

		protected HttpContent RequestBodyContent {
			get {
				var json = RequestBodyJson;
				return string.IsNullOrEmpty(json) ? null : new StringContent(json, Encoding.UTF8, "application/json");
			}
		}

		protected string RequestBodyJson {
			get {
				if (RequestBody == null) { return null; }
				return JsonConvert.SerializeObject(RequestBody, new JsonSerializerSettings {
					Formatting = Formatting.Indented,
					NullValueHandling = NullValueHandling.Ignore,
					ContractResolver = new SkipDefaultPropertyValuesContractResolver()
				});
			}
		}

		protected virtual void SetRequestHeaders(HttpRequestMessage request) {
			request.Headers.Add("trakt-api-key", _client.Authentication.ClientId);
			request.Headers.Add("trakt-api-version", _client.Configuration.ApiVersion.ToString(CultureInfo.InvariantCulture));
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			if (Authenticate) {
				if (!_client.Authentication.Authenticated) {
					throw new InvalidOperationException("Authentication is required for this request type but the authentication parameters for the current authentication mode are invalid");
				}
				switch (_client.Authentication.AuthenticationMode) {
					case TraktAuthenticationMode.OAuth:
						request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _client.Authentication.CurrentOAuthAccessToken.AccessToken);
						break;
					case TraktAuthenticationMode.Simple:
						request.Headers.TryAddWithoutValidation("trakt-user-login", _client.Authentication.LoginUsernameOrEmail);
						request.Headers.TryAddWithoutValidation("trakt-user-token", _client.Authentication.CurrentSimpleAccessToken);
					break;
				}
			}
		}

		public async Task<TResponse> SendAsync() {
			ValidateParameters(); //Expected to throw an exception on invalid parameters.

			var cl = _client.HttpMessageHandler != null ? new HttpClient(_client.HttpMessageHandler) : new HttpClient();
			var request = new HttpRequestMessage(Method, Url) { Content = RequestBodyContent };
			SetRequestHeaders(request);

			if (BeforeRequest != null) { //Raise event before request, and offer subscribers the opportunity to abort the request
				var eventArgs = new TraktBeforeRequestEventArgs(request, RequestBodyJson ?? string.Empty, cl);
				BeforeRequest(this, eventArgs);
				if (eventArgs.Cancel) { return default(TResponse); }
			}
			var response = await cl.SendAsync(request);
			var responseText = await response.Content.ReadAsStringAsync();
			if (AfterRequest != null) { AfterRequest(this, new TraktAfterRequestEventArgs(response, responseText, request, RequestBodyJson ?? string.Empty, cl)); } //Raise event after request
			cl.Dispose();

			if (!response.IsSuccessStatusCode) {
				TraktErrorResponse traktErrorResponse = null;
				try {
					traktErrorResponse = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TraktErrorResponse>(responseText));
				} catch { }
				if (traktErrorResponse == null || string.IsNullOrEmpty(traktErrorResponse.Description)) {
					try {
						if (response.StatusCode == HttpStatusCode.Unauthorized) {
							var traktLoginErrorResponse = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TraktLoginErrorResponse>(responseText));
							traktErrorResponse = new TraktErrorResponse {Description = traktLoginErrorResponse.Message, Error = "login_failed"};
						}
					} catch { }
				}
				traktErrorResponse = traktErrorResponse ?? new TraktErrorResponse();
				var message = string.IsNullOrEmpty(traktErrorResponse.Description)
					? "The Trakt API threw an error with no content. Refer to the StatusCode for an indication of the problem."
					: traktErrorResponse.Description;
				switch (response.StatusCode) {
					case HttpStatusCode.NotFound:
						throw new TraktNotFoundException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.BadRequest:
						throw new TraktBadRequestException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.Unauthorized:
						throw new TraktUnauthorizedException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.Forbidden:
						throw new TraktForbiddenException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.MethodNotAllowed:
						throw new TraktMethodNotFoundException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.Conflict:
						TraktConflictErrorResponse traktConflictErrorResponse = null;
						try {
							traktConflictErrorResponse = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TraktConflictErrorResponse>(responseText));
						} catch { }
						traktConflictErrorResponse = traktConflictErrorResponse ?? new TraktConflictErrorResponse();
						throw new TraktConflictException(traktErrorResponse, Url, RequestBodyJson, responseText, traktConflictErrorResponse.ExpiresAt);
					case (HttpStatusCode)422:
						throw new TraktUnprocessableEntityException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case (HttpStatusCode)429:
						throw new TraktRateLimitExceededException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.InternalServerError:
						throw new TraktServerErrorException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.ServiceUnavailable:
						throw new TraktServiceUnavailableException(traktErrorResponse, Url, RequestBodyJson, responseText);
				}
				throw new TraktException(message, response.StatusCode, traktErrorResponse, Url, RequestBodyJson, responseText);
			}

			if (string.IsNullOrEmpty(responseText) || response.StatusCode == HttpStatusCode.NoContent) {
				return default(TResponse);
			}
			return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResponse>(responseText));
		}

	}

}