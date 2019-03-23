﻿using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities {

	/// <summary>An episode with metadata related to a user's rating of that episode</summary>
	[Serializable]
	public class TraktEpisodeWithRatingsMetadata : TraktEpisode {

		/// <summary>The UTC date when the rating was made</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The rating</summary>
		[JsonProperty(PropertyName = "rating")]
		new public TraktRating Rating { get; set; }

	}

}