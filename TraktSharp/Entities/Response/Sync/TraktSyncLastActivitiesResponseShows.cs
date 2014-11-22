using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncLastActivitiesResponseShows {

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "watchlisted_at")]
		public DateTime? WatchlistedAt { get; set; }

		[JsonProperty(PropertyName = "commented_at")]
		public DateTime? CommentedAt { get; set; }

	}

}