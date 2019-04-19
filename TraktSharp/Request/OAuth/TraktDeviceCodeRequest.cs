using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Enums;

namespace TraktSharp.Request.OAuth {

	internal class TraktDeviceCodeRequest : TraktPostRequest<TraktDeviceCodeResponse, TraktDeviceCodeRequestBody> {

		internal TraktDeviceCodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "oauth/device/code";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Forbidden;

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.ClientId)) {
				throw new ArgumentException("ClientID not set");
			}
		}

	}

}