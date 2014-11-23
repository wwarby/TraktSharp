using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktConnections {

		[JsonProperty(PropertyName = "facebook")]
		public bool? Facebook { get; set; }

		[JsonProperty(PropertyName = "twitter")]
		public bool? Twitter { get; set; }

		[JsonProperty(PropertyName = "tumblr")]
		public bool? Tumblr { get; set; }

	}

}