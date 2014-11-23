using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktEpisodeWithWatchedMetadata : TraktEpisode {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

	}

}