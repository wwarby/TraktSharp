using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Checkin {

	[Serializable]
	public class TraktCheckinMovieResponse {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}