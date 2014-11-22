using System;
using System.Linq;

namespace TraktSharp {

	public class TraktConfiguration {

		public TraktConfiguration(TraktClient client) {
			Client = client;
			ApiVersion = 2;
			ForceAuthentication = true; //TODO: Temporary, whilst the app is not approved
		}

		public TraktClient Client { get; private set; }

		public decimal ApiVersion { get; set; }

		public bool ForceAuthentication { get; set; }

		public string BaseUrl { get { return string.Format("http://api.v{0}.trakt.tv/", ApiVersion); } }

	}

}