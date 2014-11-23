using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieWithWatchedMetadata : TraktMovie {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

	}

}