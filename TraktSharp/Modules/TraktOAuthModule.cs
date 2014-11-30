using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Helpers;
using TraktSharp.Request.OAuth;

namespace TraktSharp.Modules {

	public class TraktOAuthModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktOAuthModule(TraktClient client) : base(client) { }

		public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync() {
			return await GetOAuthTokenAsync(Client.Authentication.AuthorizationCode, Client.Authentication.ClientId, Client.Authentication.ClientSecret, Client.Authentication.RedirectUri, EnumsHelper.GetDescription(OAuthTokenGrantType.AuthorizationCode));
		}

		public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync(string code, string clientId, string clientSecret, string redirectUri, string grantType) {
			return await SendAsync(new TraktOAuthTokenRequest(Client) {
				RequestBody = new TraktOAuthTokenRequestBody {
					Code = code,
					ClientId = clientId,
					ClientSecret = clientSecret,
					RedirectUri = redirectUri,
					GrantType = grantType
				}
			});
		}

	}

}