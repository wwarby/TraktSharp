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
using TraktSharp.Exceptions;
using TraktSharp.Helpers;

namespace TraktSharp.Request {

	public abstract class TraktRequest<TResponse, TRequestBody> where TRequestBody : class {

		private readonly TraktClient _client;

		protected TraktRequest(TraktClient client) {
			_client = client;
			Pagination = new PaginationOptions();
		}

		public ExtendedOption Extended { get; set; }

		public PaginationOptions Pagination { get; set; }

		private bool _authenticate;

		public bool Authenticate {
			get {
				if (_client.Configuration.ForceAuthentication && OAuthRequirement != OAuthRequirement.Forbidden) { return true; }
				if (OAuthRequirement == OAuthRequirement.Required) { return true; }
				if (OAuthRequirement == OAuthRequirement.Forbidden) { return false; }
				return _authenticate;
			}
			set {
				if (!value && OAuthRequirement == OAuthRequirement.Required) { throw new InvalidOperationException("This request type requires authentication"); }
				if (!value && OAuthRequirement == OAuthRequirement.Forbidden) { throw new InvalidOperationException("This request type does not allow authentication"); }
				_authenticate = value;
			}
		}

		protected abstract HttpMethod Method { get; }

		protected abstract string PathTemplate { get; }

		protected abstract OAuthRequirement OAuthRequirement { get; }

		protected virtual bool SupportsPagination { get { return false; } }

		protected virtual void ValidateParameters() { }

		protected virtual IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) { return pathParameters; }

		private string Path {
			get {
				return GetPathParameters(new Dictionary<string, string>())
					.Aggregate(PathTemplate.ToLower(), (current, parameter) => current.Replace("{" + parameter.Key.ToLower() + "}", parameter.Value.ToLower()))
					.TrimEnd(new[] {'/'});
			}
		}

		protected virtual IEnumerable<KeyValuePair<string, string>> GetQueryStringParameters(Dictionary<string, string> queryStringParameters) {
			if (Extended != ExtendedOption.Unspecified) {
				queryStringParameters["extended"] = EnumsHelper.GetDescription(Extended);
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

		public string Url { get { return string.Format("{0}{1}{2}", _client.Configuration.BaseUrl, Path, QueryString); } }

		public TRequestBody RequestBody { get; set; }

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
					DefaultValueHandling = DefaultValueHandling.Ignore
				});
			}
		}

		protected virtual void SetRequestHeaders(HttpRequestMessage request) {
			request.Headers.Add("trakt-api-key", _client.Authentication.ClientId);
			request.Headers.Add("trakt-api-version", _client.Configuration.ApiVersion.ToString(CultureInfo.InvariantCulture));
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			if (Authenticate) {
				if (_client.Authentication.CurrentAccessToken == null || string.IsNullOrEmpty(_client.Authentication.CurrentAccessToken.AccessToken)) {
					throw new InvalidOperationException("Authentication is required for this request type, but the current access token is not set");
				}
				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _client.Authentication.CurrentAccessToken.AccessToken);
			}
		}

		public async Task<TResponse> SendAsync() {
			ValidateParameters(); //Expected to throw an exception on invalid parameters.

			var cl = _client.HttpMessageHandler != null ? new HttpClient(_client.HttpMessageHandler) : new HttpClient();
			var request = new HttpRequestMessage(Method, Url) {Content = RequestBodyContent};
			SetRequestHeaders(request);
			var response = await cl.SendAsync(request);
			var responseText = await response.Content.ReadAsStringAsync();
			cl.Dispose();

			if (!response.IsSuccessStatusCode) {
				TraktErrorResponse traktErrorResponse = null;
				try {
					traktErrorResponse = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TraktErrorResponse>(responseText));
				} catch {}
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
						} catch {}
						traktConflictErrorResponse = traktConflictErrorResponse ?? new TraktConflictErrorResponse();
						throw new TraktConflictException(traktErrorResponse, Url, RequestBodyJson, responseText, traktConflictErrorResponse.ExpiresAt);
						//case HttpStatusCode.UnprocessableEntity: //TODO: No such enumeration member. Must decide what to do about this
						//	throw new TraktUnprocessableEntityException(traktError, Url, RequestBodyJson, responseText);
						//case HttpStatusCode.RateLimitExceeded: //TODO: No such enumeration member. Must decide what to do about this
						//	throw new TraktRateLimitExceededException(traktError, Url, RequestBodyJson, responseText);
					case HttpStatusCode.InternalServerError:
						throw new TraktServerErrorException(traktErrorResponse, Url, RequestBodyJson, responseText);
					case HttpStatusCode.ServiceUnavailable:
						throw new TraktServiceUnavailableException(traktErrorResponse, Url, RequestBodyJson, responseText);
				}
				throw new TraktException(message, response.StatusCode, traktErrorResponse, Url, RequestBodyJson, responseText);
			}

			if (string.IsNullOrEmpty(responseText)) {
				return default(TResponse);
			}
			return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResponse>(responseText));
		}

	}

}