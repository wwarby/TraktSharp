using System;
using System.Globalization;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of unique identifiers for an episode in various web services</summary>
	[Serializable]
	public class TraktEpisodeIds {

		/// <summary>The Trakt numeric ID for this item. If available, this is the best ID to use when calling API methods that take an ID as a parameter.</summary>
		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		/// <summary>The numeric ID for this item from thetvdb.com</summary>
		[JsonProperty(PropertyName = "tvdb")]
		public int? Tvdb { get; set; }

		/// <summary>The ID for this item from imdb.com. This should always start with <c>tt</c>.</summary>
		[JsonProperty(PropertyName = "imdb")]
		public string Imdb { get; set; }

		/// <summary>The numeric ID for this item from themoviedb.org</summary>
		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		/// <summary>The numeric ID for this item from tvrage.com</summary>
		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

		/// <summary>Tests if at least one of the IDs for this item has been set</summary>
		/// <returns><c>true</c> if one or more of the IDs for this item has a non-default value, otherwise <c>false</c></returns>
		public bool HasAnyValuesSet() => Trakt > 0 || Tvdb > 0 || !string.IsNullOrEmpty(Imdb) || Tmdb > 0 || TvRage > 0;

		/// <summary>Get the most reliable ID from those that have been set for this item, for use in methods where any ID type can be passed</summary>
		/// <returns>The ID as a string</returns>
		public string GetBestId() {
			if (Trakt.GetValueOrDefault() > 0) { return Trakt.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (!string.IsNullOrEmpty(Imdb)) { return Imdb; }
			return string.Empty;
		}

	}

}