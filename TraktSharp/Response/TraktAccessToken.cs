using System;
using System.Linq;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktAccessToken {

		public string AccessToken { get; set; }

		public string AccessScope { get; set; }

		public DateTime AccessTokenExpires { get; set; }

	}

}