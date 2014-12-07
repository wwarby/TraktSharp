using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktWatchedShowsResponseItemSeason {

		/// <summary>The season number</summary>
		[JsonProperty(PropertyName = "number")]
		public int SeasonNumber { get; set; }

		/// <summary>A collection of episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktWatchedShowsResponseItemEpisode> Episodes { get; set; }

	}

}