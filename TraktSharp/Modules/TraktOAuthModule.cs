using System.Threading.Tasks;
using TraktSharp.Entities.RequestBody.OAuth;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Enums;
using TraktSharp.Exceptions;
using TraktSharp.Helpers;
using TraktSharp.Request.OAuth;

namespace TraktSharp.Modules {

    /// <summary>Provides API methods in the OAuth namespace</summary>
    public class TraktOAuthModule : TraktModuleBase {

        /// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
        /// <param name="client">The owning instance of <see cref="TraktClient"/></param>
        public TraktOAuthModule(TraktClient client) : base(client) { }

        /// <summary>Requests Device codes from Trakt for Authentication on a separate device.</summary>
        /// <returns>Trakt Device Code Response.</returns>
        public async Task<TraktDeviceCodeResponse> GenerateDeviceCodes() {
            return await SendAsync(new TraktDeviceCodeRequest(Client)
            {
                RequestBody = new TraktDeviceCodeRequestBody
                {
                    ClientId = Client.Authentication.ClientId
                }
            });
        }

        /// <summary>Checks the current Device Code to see if it was successful or failed.</summary>
        /// <param name="code">Device Code string</param>
        /// <returns>Authentication Response</returns>
        public async Task<TraktOAuthTokenResponse> CheckDeviceCode(string code) {
            try
            {
                return await SendAsync(new TraktDeviceCodeTokenRequest(Client)
                {
                    RequestBody = new TraktDeviceCodeTokenRequestBody
                    {
                        Code = code,
                        ClientId = Client.Authentication.ClientId,
                        ClientSecret = Client.Authentication.ClientSecret
                    }
                });
            }
            catch (TraktException ex)
            {
                var errorcode = (int)ex.StatusCode;
                switch (errorcode)
                {
                    case 400:
                        throw new TraktException("Authentication Pending", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody); ;
                    case 404:
                        throw new TraktException("Device Not Found", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody);
                    case 409:
                        throw new TraktException("User already approved this code", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody);
                    case 410:
                        throw new TraktException("Token Expired", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody);
                    case 418:
                        throw new TraktException("Token Denied", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody);
                    case 429:
                        throw new TraktException("Your app is polling too quickly", ex.StatusCode, new Entities.TraktErrorResponse(), ex.RequestUrl, ex.ResponseBody, ex.ResponseBody);
                }
            }
            return null;
        }

        /// <summary>
        /// Use the authorization code parameter sent back to <see cref="TraktAuthentication.OAuthRedirectUri"/> to get a <see cref="TraktOAuthAccessToken"/>
        /// (stored in <see cref="TraktAuthentication.CurrentOAuthAccessToken"/>. Save the <see cref="TraktOAuthAccessToken"/> and restore it to
        /// <see cref="TraktAuthentication.CurrentOAuthAccessToken"/> during initialization.
        /// </summary>
        /// <returns>See summary</returns>
        public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync() {
            return await GetOAuthTokenAsync(Client.Authentication.AuthorizationCode, Client.Authentication.ClientId, Client.Authentication.ClientSecret, Client.Authentication.OAuthRedirectUri, TraktOAuthTokenGrantType.AuthorizationCode);
        }

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
        public async Task<TraktOAuthTokenResponse> GetOAuthTokenAsync(string code, string clientId, string clientSecret, string redirectUri, TraktOAuthTokenGrantType grantType) {
            TraktOAuthTokenRequestBody body = null;
            if (grantType == TraktOAuthTokenGrantType.AuthorizationCode)
            {
                body = new TraktOAuthTokenRequestBody
                {
                    Code = code,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUri,
                    GrantType = TraktEnumHelper.GetDescription(grantType)
                };
            }
            else
            {
                body = new TraktOAuthTokenRequestBody
                {
                    RefreshToken = code,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUri,
                    GrantType = TraktEnumHelper.GetDescription(grantType)
                };
            }

            return await SendAsync(new TraktOAuthTokenRequest(Client)
            {
                RequestBody = body
            });
        }
    }
}