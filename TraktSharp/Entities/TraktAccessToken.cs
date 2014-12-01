using System;
using System.Linq;

namespace TraktSharp.Entities {

	/// <summary>An OAuth access token issued by the Trakt API</summary>
	[Serializable]
	public class TraktAccessToken {

		/// <summary>The access token</summary>
		public string AccessToken { get; set; }

		/// <summary>The scope of access provided by the access token</summary>
		public string AccessScope { get; set; }

		/// <summary>The UTC date when the access token expires</summary>
		public DateTime AccessTokenExpires { get; set; }

	}

}