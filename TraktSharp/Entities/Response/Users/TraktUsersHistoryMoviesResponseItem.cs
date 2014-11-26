using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	[Serializable]
	public class TraktUsersHistoryMoviesResponseItem {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		[JsonProperty(PropertyName = "action")]
		public string Action { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}