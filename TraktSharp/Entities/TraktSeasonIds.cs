using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of unique identifiers for a season in various web services</summary>
	[Serializable]
	public class TraktSeasonIds {

		/// <summary>The numeric ID for this item from thetvdb.com</summary>
		[JsonProperty(PropertyName = "tvdb")]
		public int? Tvdb { get; set; }

		/// <summary>The numeric ID for this item from themoviedb.org</summary>
		[JsonProperty(PropertyName = "tmdb")]
		public int? Tmdb { get; set; }

		/// <summary>The numeric ID for this item from tvrage.com</summary>
		[JsonProperty(PropertyName = "tvrage")]
		public int? TvRage { get; set; }

		/// <summary>Tests if at least one of the IDs for this item has been set</summary>
		/// <returns><c>true</c> if one or more of the IDs for this item has a non-default value, otherwise <c>false</c></returns>
		public bool HasAnyValuesSet() {
			return Tvdb > 0 || Tmdb > 0 || TvRage > 0;
		}

	}

}