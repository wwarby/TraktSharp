using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktEpisodeIds {

		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		[JsonProperty(PropertyName = "tvdb")]
		public int? Tvdb { get; set; }

		[JsonProperty(PropertyName = "imdb")]
		public string Imdb { get; set; }

		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

	}

}