﻿using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Enums;
using TraktSharp.Helpers;
using TraktSharp.Request.OAuth;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the OAuth namespace</summary>
	public class TraktOAuthModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktOAuthModule(TraktClient client) : base(client) { }

		/// <summary>
		/// Use the authorization code parameter sent back to <see cref="TraktAuthentication.OAuthRedirectUri"/> to get a <see cref="TraktOAuthAccessToken"/>
		/// (stored in <see cref="TraktAuthentication.CurrentOAuthAccessToken"/>. Save the <see cref="TraktOAuthAccessToken"/> and restore it to 
		/// <see cref="TraktAuthentication.CurrentOAuthAccessToken"/> during initialization.
		/// </summary>
		/// <returns>See summary</returns>
		public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync() => await GetOAuthTokenAsync(Client.Authentication.AuthorizationCode, Client.Authentication.ClientId, Client.Authentication.ClientSecret, Client.Authentication.OAuthRedirectUri, TraktOAuthTokenGrantType.AuthorizationCode);

		/// <summary>
		/// Use the authorization code parameter sent back to <see cref="TraktAuthentication.OAuthRedirectUri"/> to get a <see cref="TraktOAuthAccessToken"/>
		/// (stored in <see cref="TraktAuthentication.CurrentOAuthAccessToken"/>. Save the <see cref="TraktOAuthAccessToken"/> and restore it to 
		/// <see cref="TraktAuthentication.CurrentOAuthAccessToken"/> during initialization.
		/// </summary>
		/// <param name="code">The authorization code returned from OAuth</param>
		/// <param name="clientId">Get this from your app settings</param>
		/// <param name="clientSecret">Get this from your app settings</param>
		/// <param name="redirectUri">The uri to which Trakt should redirect upon successful authentication. Refer to <see cref="TraktAuthentication.OAuthRedirectUri"/> for further details.</param>
		/// <param name="grantType">The requested grant type</param>
		/// <returns>See summary</returns>
		public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync(string code, string clientId, string clientSecret, string redirectUri, TraktOAuthTokenGrantType grantType) =>
			await SendAsync(new TraktOAuthTokenRequest(Client) {
				RequestBody = new TraktOAuthTokenRequestBody {
					Code = code,
					ClientId = clientId,
					ClientSecret = clientSecret,
					RedirectUri = redirectUri,
					GrantType = TraktEnumHelper.GetDescription(grantType)
				}
			});

	}

}