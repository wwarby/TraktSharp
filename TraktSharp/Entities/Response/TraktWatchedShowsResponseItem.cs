using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktWatchedShowsResponseItem {

		/// <summary>The number of times the show has been played</summary>
		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

		/// <summary>The UTC date when the show was last watched</summary>
		[JsonProperty(PropertyName = "last_watched_at")]
		public DateTimeOffset? LastWatchedAt { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>A collection of seasons</summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktWatchedShowsResponseItemSeason> Seasons { get; set; }

	}

}