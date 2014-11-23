using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonWithWatchedMetadata : TraktSeason {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithWatchedMetadata> Episodes { get; set; }

	}

}