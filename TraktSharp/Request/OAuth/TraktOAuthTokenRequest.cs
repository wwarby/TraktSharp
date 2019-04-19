using System;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Enums;

namespace TraktSharp.Request.OAuth {

	internal class TraktOAuthTokenRequest : TraktPostRequest<TraktOAuthTokenResponse, TraktOAuthTokenRequestBody> {

		internal TraktOAuthTokenRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "oauth/token";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Forbidden;

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Code)) {
				throw new ArgumentException("Code not set.");
			}
			if (string.IsNullOrEmpty(RequestBody.ClientId)) {
				throw new ArgumentException("ClientId not set.");
			}
			if (string.IsNullOrEmpty(RequestBody.ClientSecret)) {
				throw new ArgumentException("ClientSecret not set.");
			}
			if (string.IsNullOrEmpty(RequestBody.RedirectUri)) {
				throw new ArgumentException("RedirectUri not set.");
			}
		}

	}

}