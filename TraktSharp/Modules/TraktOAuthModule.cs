using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Helpers;
using TraktSharp.Request.OAuth;

namespace TraktSharp.Modules {

	public class TraktOAuthModule {

		public TraktOAuthModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktOAuthTokenResponse> TokenAsync() {
			return await TokenAsync(Client.Authentication.AuthorizationCode, Client.Authentication.ClientId, Client.Authentication.ClientSecret, Client.Authentication.RedirectUri, EnumsHelper.GetDescription(OAuthTokenGrantType.AuthorizationCode));
		}

		public async Task<TraktOAuthTokenResponse> TokenAsync(string code, string clientId, string clientSecret, string redirectUri, string grantType) {
			return await new TraktOAuthTokenRequest(Client) {
				RequestBody = new TraktOAuthTokenRequestBody {
					Code = code,
					ClientId = clientId,
					ClientSecret = clientSecret,
					RedirectUri = redirectUri,
					GrantType = grantType
				}
			}.SendAsync();
		}

	}

}