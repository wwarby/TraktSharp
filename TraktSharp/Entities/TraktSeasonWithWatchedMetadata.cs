using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A season with metadata related to a user's watched status in regard to that season</summary>
	[Serializable]
	public class TraktSeasonWithWatchedMetadata : TraktSeason {

		/// <summary>The UTC date when the user watched the season</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset? WatchedAt { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's watched status in regard to each episode</summary>
		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithWatchedMetadata> Episodes { get; set; }

	}

}