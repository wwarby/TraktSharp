using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities {

	/// <summary>A season with metadata related to a user's rating of that season</summary>
	[Serializable]
	public class TraktSeasonWithRatingsMetadata : TraktSeason {

		/// <summary>The UTC date when the rating was made</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		/// <summary>The rating</summary>
		[JsonProperty(PropertyName = "rating")]
		public new TraktRating Rating { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's rating in regard to each episode</summary>
		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithRatingsMetadata> Episodes { get; set; }

	}

}