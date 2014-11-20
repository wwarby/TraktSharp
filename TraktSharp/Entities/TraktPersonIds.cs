using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPersonIds {

		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

		[JsonProperty(PropertyName = "imdb")]
		public string Imdb { get; set; }

		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

	}

}