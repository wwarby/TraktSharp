using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities {

	/// <summary>A show with metadata related to a user's rating of that show</summary>
	[Serializable]
	public class TraktShowWithRatingsMetadata : TraktShow {

		/// <summary>The UTC date when the rating was made</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		/// <summary>The rating</summary>
		[JsonProperty(PropertyName = "rating")]
		public new TraktRating Rating { get; set; }

		/// <summary>A collection of seasons with metadata related to a user's rating in regard to each season</summary>
		[JsonProperty(PropertyName = "seasons")]
		public new IEnumerable<TraktSeasonWithRatingsMetadata> Seasons { get; set; }

	}

}