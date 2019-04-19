using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncResponseNotFound {

		/// <summary>A collection of movies</summary>
		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovie> Movies { get; set; }

		/// <summary>A collection of shows</summary>
		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShow> Shows { get; set; }

		/// <summary>A collection of seasons</summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeason> Seasons { get; set; }

		/// <summary>A collection of episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

	}

}