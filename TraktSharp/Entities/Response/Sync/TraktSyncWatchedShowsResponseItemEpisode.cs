using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncWatchedShowsResponseItemEpisode {

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

	}

}