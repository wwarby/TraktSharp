using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktWatchedMoviesResponseItem {

		/// <summary>The number of times the movie has been played</summary>
		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

		/// <summary>The UTC date when the movie was last watched</summary>
		[JsonProperty(PropertyName = "last_watched_at")]
		public DateTime? LastWatchedAt { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}