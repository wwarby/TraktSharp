using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An episode with metadata related to a user's watched status in regard to that episode</summary>
	[Serializable]
	public class TraktEpisodeWithWatchedMetadata : TraktEpisode {

		/// <summary>The UTC date when the user watched the episode</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

	}

}