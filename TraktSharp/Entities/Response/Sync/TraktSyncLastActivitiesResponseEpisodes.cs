using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseEpisodes {

		/// <summary>The UTC date when the user most recently watched an episode</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset? WatchedAt { get; set; }

		/// <summary>The UTC date when the user most recently collected an episode</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

		/// <summary>The UTC date when the user most recently rated an episode</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The UTC date when the user most recently watchlisted an episode</summary>
		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTimeOffset? WatchlistedAt { get; set; }

		/// <summary>The UTC date when the user most recently commented on an episode</summary>
		[JsonProperty(PropertyName = "commented_at")]
		public DateTimeOffset? CommentedAt { get; set; }

		/// <summary>The UTC date when the user most recently paused an episode</summary>
		[JsonProperty(PropertyName = "paused_at")]
		public DateTimeOffset? PausedAt { get; set; }

	}

}