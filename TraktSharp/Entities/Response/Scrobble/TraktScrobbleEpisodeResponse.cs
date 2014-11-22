using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Scrobble {

	[Serializable]
	public class TraktScrobbleEpisodeResponse {

		[JsonProperty(PropertyName = "action")]
		public string Action { get; set; }

		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}