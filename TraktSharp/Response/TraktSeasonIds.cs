using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktSeasonIds {

		[JsonProperty(PropertyName = "tvdb")]
		public int? Tvdb { get; set; }

		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

	}

}