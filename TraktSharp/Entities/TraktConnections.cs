using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>
	///     A set of social media connection indicators indicating which social networks a user's account has connections
	///     to
	/// </summary>
	[Serializable]
	public class TraktConnections {

		/// <summary>Indicates that the user's account has a connection to Facebook</summary>
		[JsonProperty(PropertyName = "facebook")]
		public bool? Facebook { get; set; }

		/// <summary>Indicates that the user's account has a connection to Twitter</summary>
		[JsonProperty(PropertyName = "twitter")]
		public bool? Twitter { get; set; }

		/// <summary>Indicates that the user's account has a connection to Tumblr</summary>
		[JsonProperty(PropertyName = "tumblr")]
		public bool? Tumblr { get; set; }

		/// <summary>Indicates that the user's account has a connection to Google</summary>
		[JsonProperty(PropertyName = "google")]
		public bool? Google { get; set; }

	}

}