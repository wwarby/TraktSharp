using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktWatchedMoviesResponseItem {

		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

		[JsonProperty(PropertyName = "last_watched_at")]
		public DateTime? LastWatchedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}