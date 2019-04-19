using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseShows {

		/// <summary>The UTC date when the user most recently rated a show</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The UTC date when the user most recently watchlisted a show</summary>
		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTimeOffset? WatchlistedAt { get; set; }

		/// <summary>The UTC date when the user most recently commented on a show</summary>
		[JsonProperty(PropertyName = "commented_at")]
		public DateTimeOffset? CommentedAt { get; set; }

	}

}