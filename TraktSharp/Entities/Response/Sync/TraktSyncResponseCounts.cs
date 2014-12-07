using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncResponseCounts {

		/// <summary>The number of movies</summary>
		[JsonProperty(PropertyName = "movies")]
		public int? Movies { get; set; }

		/// <summary>The number of shows</summary>
		[JsonProperty(PropertyName = "shows")]
		public int? Shows { get; set; }

		/// <summary>The number of seasons</summary>
		[JsonProperty(PropertyName = "seasons")]
		public int? Seasons { get; set; }

		/// <summary>The number of episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public int? Episodes { get; set; }

	}

}