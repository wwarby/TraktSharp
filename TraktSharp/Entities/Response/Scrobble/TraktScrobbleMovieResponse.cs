using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Scrobble {

	[Serializable]
	public class TraktScrobbleMovieResponse {

		[JsonProperty(PropertyName = "action")]
		public string Action { get; set; }

		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}