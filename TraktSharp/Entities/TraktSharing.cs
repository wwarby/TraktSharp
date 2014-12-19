using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A set of social media connection indicators indicating where a resource has been (or will be) shared on social media sites</summary>
	[Serializable]
	public class TraktSharing {

		/// <summary>Indicates that the resource has been (or will be) shared on Facebook</summary>
		[JsonProperty(PropertyName = "facebook")]
		public bool? Facebook { get; set; }

		/// <summary>Indicates that the resource has been (or will be) shared on Twitter</summary>
		[JsonProperty(PropertyName = "twitter")]
		public bool? Twitter { get; set; }

		/// <summary>Indicates that the resource has been (or will be) shared on Tumblr</summary>
		[JsonProperty(PropertyName = "tumblr")]
		public bool? Tumblr { get; set; }

		/// <summary>Indicates that the resource has been (or will be) shared on Google</summary>
		[JsonProperty(PropertyName = "google")]
		public bool? Google { get; set; }

	}

}