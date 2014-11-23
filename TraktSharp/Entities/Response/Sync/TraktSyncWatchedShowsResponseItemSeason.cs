using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncWatchedShowsResponseItemSeason {

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktSyncWatchedShowsResponseItemEpisode> Episodes { get; set; }

	}

}