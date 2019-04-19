using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktWatchedShowsResponseItemEpisode {

		/// <summary>The episode number</summary>
		[JsonProperty(PropertyName = "number")]
		public int EpisodeNumber { get; set; }

		/// <summary>The number of times the episode has been played</summary>
		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

	}

}