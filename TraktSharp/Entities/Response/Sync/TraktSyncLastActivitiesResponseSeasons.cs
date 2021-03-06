﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseSeasons {

		/// <summary>The UTC date when the user most recently rated a season</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTimeOffset? RatedAt { get; set; }

		/// <summary>The UTC date when the user most recently watchlisted a season</summary>
		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTimeOffset? WatchlistedAt { get; set; }

		/// <summary>The UTC date when the user most recently commented on a season</summary>
		[JsonProperty(PropertyName = "commented_at")]
		public DateTimeOffset? CommentedAt { get; set; }

	}

}