using System;
using System.Linq;
using TraktSharp.Response;

namespace TraktSharp.Examples {

	public class SavedState {

		public TraktAccessToken AccessToken { get; set; }
		public string Username { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }

	}

}