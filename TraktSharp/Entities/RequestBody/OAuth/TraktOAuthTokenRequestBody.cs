using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.OAuth {

	/// <summary>Request body parameters for an OAuth token request</summary>
	[Serializable]
	public class TraktOAuthTokenRequestBody {

		/// <summary>The authorization code returned from OAuth</summary>
		[JsonProperty(PropertyName = "code")]
		public string Code { get; set; }

		/// <summary>Get this from your app settings</summary>
		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }

		/// <summary>Get this from your app settings</summary>
		[JsonProperty(PropertyName = "client_secret")]
		public string ClientSecret { get; set; }

		/// <summary>The uri to which Trakt should redirect upon successful authentication. Refer to <see cref="TraktAuthentication.OAuthRedirectUri"/> for further details.</summary>
		[JsonProperty(PropertyName = "redirect_uri")]
		public string RedirectUri { get; set; }

		/// <summary>The requested grant type</summary>
		[JsonProperty(PropertyName = "grant_type")]
		public string GrantType { get; set; }

	}

}