using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A movie with metadata related to a user's watched status in regard to that movie</summary>
	[Serializable]
	public class TraktMovieWithWatchedMetadata : TraktMovie {

		/// <summary>The UTC date when the user watched the movie</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

	}

}