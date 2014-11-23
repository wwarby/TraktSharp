using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.OAuth;
using TraktSharp.Helpers;

namespace TraktSharp {

	public class TraktAuthentication {

		public TraktAuthentication(TraktClient client) {
			Client = client;
			AntiForgeryToken = Guid.NewGuid().ToString();
			RedirectUri = "app://authorized"; //This can be changed to any string, but must match the value entered at http://api.v2.trakt.tv/oauth/applications
		}

		public TraktClient Client { get; private set; }

		private TraktAccessToken _currentAccessToken;

		public TraktAccessToken CurrentAccessToken { get { return _currentAccessToken = _currentAccessToken ?? new TraktAccessToken(); } set { _currentAccessToken = value; } }

		public string AuthorizationCode { get; internal set; }

		public string AntiForgeryToken { get; private set; }

		public string ClientId { get; set; }

		public string ClientSecret { get; set; }

		public string Username { get; set; }

		public string RedirectUri { get; set; }

		public string AuthorizationUrl {
			get {
				return string.Format("{0}/oauth/authorize?response_type=code&client_id={1}&redirect_uri={2}&state={3}&username={4}",
					Client.Configuration.BaseUrl, ClientId, HttpUtility.UrlEncode(RedirectUri), AntiForgeryToken, Username);
			}
		}

		public void ParseAuthorizationResponse(Uri uri) {
			var queryParams = HttpUtility.ParseQueryString(uri.Query);
			if (queryParams["state"] != AntiForgeryToken) {
				throw new HttpRequestValidationException("Anti-forgery token does not match");
			}
			AuthorizationCode = queryParams["code"];
		}

		public void ParseAuthorizationResponse(string url) { ParseAuthorizationResponse(new Uri(url)); }

		public async Task<TraktOAuthTokenResponse> GetAccessToken() { 
			return await Client.OAuth.GetOAuthTokenAsync(AuthorizationCode, ClientId, ClientSecret, RedirectUri, EnumsHelper.GetDescription(OAuthTokenGrantType.AuthorizationCode));
		}

	}

}