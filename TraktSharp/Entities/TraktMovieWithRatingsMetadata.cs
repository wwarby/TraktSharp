using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities {

	/// <summary>A movie with metadata related to a user's rating of that movie</summary>
	[Serializable]
	public class TraktMovieWithRatingsMetadata : TraktMovie {

		/// <summary>The UTC date when the rating was made</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The rating</summary>
		[JsonProperty(PropertyName = "rating")]
		public new TraktRating Rating { get; set; }

	}

}