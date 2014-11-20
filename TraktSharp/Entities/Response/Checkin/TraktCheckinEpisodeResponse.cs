using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Checkin {

	[Serializable]
	public class TraktCheckinEpisodeResponse {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharingOptions Sharing { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}