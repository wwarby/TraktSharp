using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.RequestBody.OAuth;
using TraktSharp.Response.OAuth;

namespace TraktSharp.Request.OAuth {

	[Serializable]
	public class TraktOAuthTokenRequest : TraktRequest<TraktOAuthTokenResponse> {

		public TraktOAuthTokenRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Post; } }

		protected override string PathTemplate { get { return "oauth/token"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Forbidden; } }

		protected override bool SupportsPagination { get { return false; } }

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktOAuthTokenRequestBody;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof(TraktOAuthTokenRequestBody).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Code)) {
				throw new ArgumentException("AuthorizationCode not set. This is usually set by calling ParseAuthorizationResponse().");
			}
			if (string.IsNullOrEmpty(requestBody.ClientId)) {
				throw new ArgumentException("ClientId not set.");
			}
			if (string.IsNullOrEmpty(requestBody.ClientSecret)) {
				throw new ArgumentException("ClientSecret not set.");
			}
			if (string.IsNullOrEmpty(requestBody.RedirectUri)) {
				throw new ArgumentException("RedirectUri not set.");
			}
		}

	}

}