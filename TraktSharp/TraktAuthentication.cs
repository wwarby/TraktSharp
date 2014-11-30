using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TraktSharp.Entities;
using TraktSharp.Helpers;
using TraktSharp.Modules;

namespace TraktSharp {

	/// <summary>Encapsulates functionality related to authentication</summary>
	public class TraktAuthentication {

		private TraktAccessToken _currentAccessToken;
		private const string _defaultRedirectUri = "app://authorized";

		/// <summary>Default constructor. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktAuthentication(TraktClient client) {
			Client = client;
			AntiForgeryToken = Guid.NewGuid().ToString();
			RedirectUri = _defaultRedirectUri;
		}

		/// <summary>The owning instance of <see cref="TraktClient"/></summary>
		public TraktClient Client { get; private set; }

		/// <summary>The current access token that will be used in all authenticated requests</summary>
		public TraktAccessToken CurrentAccessToken { get { return _currentAccessToken = _currentAccessToken ?? new TraktAccessToken(); } set { _currentAccessToken = value; } }

		/// <summary>The authorization code returned from OAuth</summary>
		public string AuthorizationCode { get; internal set; }

		/// <summary>A randomly generated anti-forgery token used in authentication requests</summary>
		public string AntiForgeryToken { get; private set; }

		/// <summary>Get this from your app settings</summary>
		public string ClientId { get; set; }

		/// <summary>Get this from your app settings</summary>
		public string ClientSecret { get; set; }

		/// <summary>The username of the user to be authenticated</summary>
		public string Username { get; set; }

		/// <summary>The uri to which Trakt should redirect upon successful authentication</summary>
		/// <remarks>
		/// For desktop applications in which the authentication session is hosted in a <c>WebBrowser</c> control and the redirection can be caught,
		/// this can be changed to any string, but must match the value entered in your app settings. A good default value to use is <c>app://authorized</c>.
		/// For web applications, this must be a valid URL within your application.
		/// </remarks>
		public string RedirectUri { get; set; }

		/// <summary>Gets the url that users must be redirected to in order to provide their credentials for OAuth authentication</summary>
		public string AuthorizationUrl {
			get {
				return string.Format("{0}/oauth/authorize?response_type=code&client_id={1}&redirect_uri={2}&state={3}&username={4}",
					Client.Configuration.BaseUrl, ClientId, HttpUtility.UrlEncode(RedirectUri), AntiForgeryToken, Username);
			}
		}

		/// <summary>Parses the uri that Trakt redirects to after successful OAuth authentication to extract the authorization code and check the anti-forgery token</summary>
		/// <param name="uri">The uri that Trakt redirected the user to</param>
		public void ParseAuthorizationResponse(Uri uri) {
			var queryParams = HttpUtility.ParseQueryString(uri.Query);
			if (queryParams["state"] != AntiForgeryToken) {
				throw new HttpRequestValidationException("Anti-forgery token does not match");
			}
			AuthorizationCode = queryParams["code"];
		}

		/// <summary>Parses the url that Trakt redirects to after successful OAuth authentication to extract the authorization code and check the anti-forgery token</summary>
		/// <param name="url">The url that Trakt redirected the user to</param>
		public void ParseAuthorizationResponse(string url) { ParseAuthorizationResponse(new Uri(url)); }

		/// <summary>Make a call to <see cref="TraktOAuthModule.GetOAuthTokenAsync()"/> and parses the result into <see cref="CurrentAccessToken"/></summary>
		/// <returns><see cref="CurrentAccessToken"/></returns>
		public async Task<TraktAccessToken> GetAccessToken() { 
			var result = await Client.OAuth.GetOAuthTokenAsync(AuthorizationCode, ClientId, ClientSecret, RedirectUri, EnumsHelper.GetDescription(OAuthTokenGrantType.AuthorizationCode));
			CurrentAccessToken = new TraktAccessToken {
				AccessToken = result.AccessToken,
				AccessTokenExpires = DateTime.Now.AddSeconds(result.ExpiresIn),
				AccessScope = result.Scope
			};
			return CurrentAccessToken;
		}

	}

}