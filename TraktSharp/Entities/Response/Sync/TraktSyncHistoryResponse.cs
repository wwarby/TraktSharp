using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities.Response.Sync {

	public class TraktSyncHistoryResponse {

		public long Id { get; set; }

		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset WatchedAt { get; set; }

		[JsonProperty(PropertyName = "type")] public TraktWatchingItemType Type { get; set; }

		[JsonProperty(PropertyName = "action")]
		public TraktHistoryAction Action { get; set; }

		public TraktEpisode Episode { get; set; }

		public TraktSeason Season { get; set; }

		public TraktShow Show { get; set; }

		public TraktMovie Movie { get; set; }

		public override string ToString() => $"{Show.Title} - {Episode.Title}: {WatchedAt.LocalDateTime.ToString()}";

	}

}