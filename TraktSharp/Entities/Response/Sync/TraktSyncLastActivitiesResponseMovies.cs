using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseMovies {

		/// <summary>The UTC date when the user most recently watched a movie</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset? WatchedAt { get; set; }

		/// <summary>The UTC date when the user most recently collected a movie</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

		/// <summary>The UTC date when the user most recently rated a movie</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The UTC date when the user most recently watchlisted a movie</summary>
		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTimeOffset? WatchlistedAt { get; set; }

		/// <summary>The UTC date when the user most recently commented on a movie</summary>
		[JsonProperty(PropertyName = "commented_at")]
		public DateTimeOffset? CommentedAt { get; set; }

	}

}