using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Checkin {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCheckinMovieResponse {

		/// <summary>The UTC date when the item was watched</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset? WatchedAt { get; set; }

		/// <summary>Indicators showing which connected social networks the action was published to</summary>
		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}