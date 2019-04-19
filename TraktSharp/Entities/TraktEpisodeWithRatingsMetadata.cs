using System;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities {

	/// <summary>An episode with metadata related to a user's rating of that episode</summary>
	[Serializable]
	public class TraktEpisodeWithRatingsMetadata : TraktEpisode {

		/// <summary>The UTC date when the rating was made</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		/// <summary>The rating</summary>
		[JsonProperty(PropertyName = "rating")]
		public new TraktRating Rating { get; set; }

	}

}