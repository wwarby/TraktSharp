using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A season of a show</summary>
	[Serializable]
	public class TraktSeason {

		/// <summary>The season number</summary>
		[JsonProperty(PropertyName = "number")]
		public int? SeasonNumber { get; set; }

		/// <summary>A collection of unique identifiers for the season in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktSeasonIds Ids { get; set; }

		/// <summary>A collection of images related to the season</summary>
		[JsonProperty(PropertyName = "images")]
		public TraktSeasonImages Images { get; set; }

		/// <summary>A collection of episodes in the season</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

		/// <summary>The number of episodes in the season</summary>
		[JsonProperty(PropertyName = "episode_count")]
		public int? EpisodeCount { get; set; }

		/// <summary>The average user rating for the season</summary>
		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

	}

}