using System;
using System.Linq;

namespace TraktSharp {

	/// <summary>Configuation settings for an instance of <see cref="TraktClient"/></summary>
	public class TraktConfiguration {

		/// <summary>Default constructor. Used internally by <see cref="TraktClient"/>.</summary>
		public TraktConfiguration(TraktClient client) {
			Client = client;
			ApiVersion = 2;
		}

		/// <summary>The owning instance of <see cref="TraktClient"/></summary>
		public TraktClient Client { get; private set; }

		/// <summary>The version of the Trakt API to use in all requests</summary>
		public decimal ApiVersion { get; set; }

		/// <summary>If <c>true</c>, the sandpit domain will be used instead of the production domain</summary>
		public bool UseSandpit { get; set; }

		/// <summary>Set to true to force authentication even on methods where authentication is optional or not required</summary>
		public bool ForceAuthentication { get; set; }

		/// <summary>The base URL for all requests</summary>
		public string BaseUrl {
			get { return UseSandpit ? string.Format("http://api.v{0}.trakt.tv/", ApiVersion) : "https://api.trakt.tv/"; }
		}

	}

}