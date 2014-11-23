using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncWatchedShowsResponseItem {

		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

		[JsonProperty(PropertyName = "last_watched_at")]
		public DateTime? LastWatchedAt { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSyncWatchedShowsResponseItemSeason> Seasons { get; set; }

	}

}