using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesEngagementResponseItem {

		/// <summary>The number of users who have watched this item</summary>
		[JsonProperty(PropertyName = "watcher_count")]
		public int? WatcherCount { get; set; }

		/// <summary>The number of times this item has been played</summary>
		[JsonProperty(PropertyName = "play_count")]
		public int? PlayCount { get; set; }

		/// <summary>The number of times this item has been collected</summary>
		[JsonProperty(PropertyName = "collected_count")]
		public int? CollectedCount { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}