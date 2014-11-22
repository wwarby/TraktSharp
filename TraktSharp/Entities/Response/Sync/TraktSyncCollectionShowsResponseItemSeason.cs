using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncCollectionShowsResponseItemSeason {

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktSyncCollectionShowsResponseItemEpisode> Episodes { get; set; }

	}

}