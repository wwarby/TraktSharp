using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSharingText {

		[JsonProperty(PropertyName = "watching")]
		public string Watching { get; set; }

		[JsonProperty(PropertyName = "watched")]
		public string Watched { get; set; }

	}

}