using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Auth;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Enums;

namespace TraktSharp.Request.Auth {

	internal class TraktAuthLoginRequest : TraktPostRequest<TraktAuthLoginResponse, TraktAuthLoginRequestBody> {

		internal TraktAuthLoginRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "auth/login";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Forbidden;

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Login)) {
				throw new ArgumentException("Login not set");
			}

			if (string.IsNullOrEmpty(RequestBody.Password)) {
				throw new ArgumentException("Password not set");
			}
		}

	}

}