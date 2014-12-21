using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Modules;

namespace TraktSharp {

	/// <summary>Encapsulates functionality related to authentication</summary>
	public class TraktAuthentication {

		private TraktOAuthAccessToken _currentOAuthAccessToken;
		private const string _defaultRedirectUri = "app://authorized";
		private const TraktAuthenticationMode _defaultAuthenticationMode = TraktAuthenticationMode.OAuth;

		/// <summary>Default constructor. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktAuthentication(TraktClient client) {
			Client = client;
			AuthenticationMode =_defaultAuthenticationMode;
			AntiForgeryToken = Guid.NewGuid().ToString();
			OAuthRedirectUri = _defaultRedirectUri;
		}

		/// <summary>The owning instance of <see cref="TraktClient"/></summary>
		public TraktClient Client { get; private set; }

		/// <summary>The method of authentication to the Trakt API</summary>
		public TraktAuthenticationMode AuthenticationMode { get; set; }

		/// <summary>The current access token that will be used in all authenticated requests</summary>
		public TraktOAuthAccessToken CurrentOAuthAccessToken {
			get { return _currentOAuthAccessToken = _currentOAuthAccessToken ?? new TraktOAuthAccessToken(); } 
			set { _currentOAuthAccessToken = value; }
		}

		/// <summary>The current access token that will be used in all authenticated requests</summary>
		public string CurrentSimpleAccessToken { get; set; }

		/// <summary>The authorization code returned from OAuth</summary>
		public string AuthorizationCode { get; private set; }

		/// <summary>A randomly generated anti-forgery token used in authentication requests</summary>
		public string AntiForgeryToken { get; private set; }

		/// <summary>Get this from your app settings</summary>
		public string ClientId { get; set; }

		/// <summary>Get this from your app settings</summary>
		public string ClientSecret { get; set; }

		/// <summary>The username of the user to be authenticated using OAuth authentication</summary>
		public string Username { get; set; }

		/// <summary>The username or email address of the user to be authenticated using token header authentication</summary>
		public string LoginUsernameOrEmail { get; set; }

		/// <summary>The uri to which Trakt should redirect upon successful authentication</summary>
		/// <remarks>
		/// For desktop applications in which the authentication session is hosted in a <c>WebBrowser</c> control and the redirection can be caught,
		/// this can be changed to any string, but must match the value entered in your app settings. A good default value to use is <c>app://authorized</c>.
		/// For web applications, this must be a valid URL within your application.
		/// </remarks>
		public string OAuthRedirectUri { get; set; }

		/// <summary>Gets the url that users must be redirected to in order to provide their credentials for OAuth authentication</summary>
		public string OAuthAuthorizationUrl {
			get {
				return string.Format("{0}/oauth/authorize?response_type=code&client_id={1}&redirect_uri={2}&state={3}&username={4}",
					Client.Configuration.BaseUrl, ClientId, HttpUtility.UrlEncode(OAuthRedirectUri), AntiForgeryToken, Username);
			}
		}

		/// <summary>Parses the uri that Trakt redirects to after successful OAuth authentication to extract the authorization code and check the anti-forgery token</summary>
		/// <param name="uri">The uri that Trakt redirected the user to</param>
		public void ParseOAuthAuthorizationResponse(Uri uri) {
			var queryParams = HttpUtility.ParseQueryString(uri.Query);
			if (queryParams["state"] != AntiForgeryToken) {
				throw new HttpRequestValidationException("Anti-forgery token does not match");
			}
			AuthorizationCode = queryParams["code"];
		}

		/// <summary>Parses the url that Trakt redirects to after successful OAuth authentication to extract the authorization code and check the anti-forgery token</summary>
		/// <param name="url">The url that Trakt redirected the user to</param>
		public void ParseOAuthAuthorizationResponse(string url) { ParseOAuthAuthorizationResponse(new Uri(url)); }

		/// <summary>Make a call to <see cref="TraktOAuthModule.GetOAuthTokenAsync()"/> to get an OAuth access token using <see cref="AuthorizationCode"/>, <see cref="ClientId"/>,
		/// <see cref="ClientSecret"/> and <see cref="OAuthRedirectUri"/>, and parse the result into <see cref="CurrentOAuthAccessToken"/></summary>
		/// <returns><see cref="CurrentOAuthAccessToken"/></returns>
		public async Task<TraktOAuthAccessToken> GetOAuthAccessToken() {
			AuthenticationMode = TraktAuthenticationMode.OAuth;
			var result = await Client.OAuth.GetOAuthTokenAsync(AuthorizationCode, ClientId, ClientSecret, OAuthRedirectUri, TraktOAuthTokenGrantType.AuthorizationCode);
			CurrentOAuthAccessToken = new TraktOAuthAccessToken {
				AccessToken = result.AccessToken,
				AccessTokenExpires = DateTime.Now.AddSeconds(result.ExpiresIn),
				AccessScope = result.Scope
			};
			return CurrentOAuthAccessToken;
		}

		/// <summary>Make a call to <see cref="TraktOAuthModule.GetOAuthTokenAsync()"/> to refresh an OAuth access token using <see cref="AuthorizationCode"/>, <see cref="ClientId"/>,
		/// <see cref="ClientSecret"/> and <see cref="OAuthRedirectUri"/>, and parse the result into <see cref="CurrentOAuthAccessToken"/></summary>
		/// <returns><see cref="CurrentOAuthAccessToken"/></returns>
		public async Task<TraktOAuthAccessToken> RefreshOAuthAccessToken() {
			//TODO: OAuth refresh currently not working - it isn't clear from the docs exactly what values should be passed in. Reported to Trakt staff.
			AuthenticationMode = TraktAuthenticationMode.OAuth;
			var result = await Client.OAuth.GetOAuthTokenAsync(CurrentOAuthAccessToken.RefreshToken, ClientId, ClientSecret, OAuthRedirectUri, TraktOAuthTokenGrantType.RefreshToken);
			CurrentOAuthAccessToken = new TraktOAuthAccessToken {
				AccessToken = result.AccessToken,
				AccessTokenExpires = DateTime.Now.AddSeconds(result.ExpiresIn),
				AccessScope = result.Scope,
				RefreshToken =  result.RefreshToken
			};
			return CurrentOAuthAccessToken;
		}

		/// <summary>
		/// Log in to the Trakt API using a username/email and password. This is a special case where the application will is allowed to use a simpler token based authenticaion
		/// instead of OAuth. In order to fall under this special use case, you will need to contact the trakt staff and get a special allowance made.
		/// </summary>
		/// <param name="usernameOrEmail">The user's username or email address</param>
		/// <param name="password">The user's password</param>
		/// <returns>A simple access token which is stored in <see cref="CurrentSimpleAccessToken"/> and used for subsequent Trakt API requests</returns>
		public async Task<string> Login(string usernameOrEmail, string password) {
			AuthenticationMode = TraktAuthenticationMode.Simple;
			if (!string.IsNullOrEmpty(usernameOrEmail)) { LoginUsernameOrEmail = usernameOrEmail; }
			var result = await Client.Auth.LoginAsync(LoginUsernameOrEmail, password);
			CurrentSimpleAccessToken = result.Token;
			return CurrentSimpleAccessToken;
		}

		/// <summary>Log out of the Trakt API. This destroys the access token created by <see cref="Login"/> on the server and the client</summary>
		/// <returns>An awaitable task</returns>
		public async Task Logout() {
			await Client.Auth.LogoutAsync();
			CurrentSimpleAccessToken = string.Empty;
		}

		/// <summary>Tests if the authentication parameters for the current authentication mode are valid</summary>
		public bool Authenticated {
			get {
				switch (AuthenticationMode) {
					case TraktAuthenticationMode.OAuth:
						return CurrentOAuthAccessToken != null && CurrentOAuthAccessToken.IsValid;
					case TraktAuthenticationMode.Simple:
						return !string.IsNullOrEmpty(LoginUsernameOrEmail) && !string.IsNullOrEmpty(CurrentSimpleAccessToken);
				}
				return false;
			}
		}

	}

}