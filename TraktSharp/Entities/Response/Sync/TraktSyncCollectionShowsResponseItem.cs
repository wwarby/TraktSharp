using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncCollectionShowsResponseItem {

		[JsonProperty(PropertyName = "last_collected_at")]
		public DateTime? LastCollectedAt { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSyncCollectionShowsResponseItemSeason> Seasons { get; set; }

	}

}