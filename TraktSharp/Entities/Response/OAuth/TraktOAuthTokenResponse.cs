using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.OAuth {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktOAuthTokenResponse {

		/// <summary>The OAuth access token</summary>
		[JsonProperty(PropertyName = "access_token")]
		public string AccessToken { get; set; }

		/// <summary>The type of the OAuth token</summary>
		[JsonProperty(PropertyName = "token_type")]
		public string TokenType { get; set; }

		/// <summary>The date when the OAuth token will expire</summary>
		[JsonProperty(PropertyName = "expires_in")]
		public int ExpiresIn { get; set; }

		/// <summary>The OAuth refresh token</summary>
		[JsonProperty(PropertyName = "refresh_token")]
		public string RefreshToken { get; set; }

		/// <summary>The scope of the OAuth token</summary>
		[JsonProperty(PropertyName = "scope")]
		public string Scope { get; set; }

	}

}