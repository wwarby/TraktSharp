using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktRatings {

		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		[JsonProperty(PropertyName = "votes")]
		public int Votes { get; set; }

		[JsonProperty(PropertyName = "distribution")]
		public Dictionary<string, int> Distribution { get; set; }

	}

}