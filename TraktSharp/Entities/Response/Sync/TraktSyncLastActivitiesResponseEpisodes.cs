using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseEpisodes {

		/// <summary>The UTC date when the user most recently watched an episode</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		/// <summary>The UTC date when the user most recently collected an episode</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

		/// <summary>The UTC date when the user most recently rated an episode</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		/// <summary>The UTC date when the user most recently watchlisted an episode</summary>
		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTime? WatchlistedAt { get; set; }

		/// <summary>The UTC date when the user most recently commented on an episode</summary>
		[JsonProperty(PropertyName = "commented_at")]
		public DateTime? CommentedAt { get; set; }

	}

}