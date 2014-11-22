using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieIds {

		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

		[JsonProperty(PropertyName = "imdb")]
		public string Imdb { get; set; }

		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		public bool HasAnyValuesSet() {
			return Trakt.HasValue || !string.IsNullOrEmpty(Slug) || !string.IsNullOrEmpty(Imdb) || Tmdb.HasValue;
		}

		public string GetBestId() {
			if (Trakt.GetValueOrDefault() > 0) { return Trakt.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (!string.IsNullOrEmpty(Slug)) { return Slug; }
			if (!string.IsNullOrEmpty(Imdb)) { return Imdb; }
			if (Tmdb.GetValueOrDefault() > 0) { return Tmdb.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			return string.Empty;
		}

	}

}