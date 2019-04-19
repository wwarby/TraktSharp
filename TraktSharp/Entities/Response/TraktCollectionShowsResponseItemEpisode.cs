using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCollectionShowsResponseItemEpisode {

		/// <summary>The episode number within the season</summary>
		[JsonProperty(PropertyName = "number")]
		public int EpisodeNumber { get; set; }

		/// <summary>The UTC date when the item was collected</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

	}

}