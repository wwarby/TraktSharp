using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncCollectionMoviesResponseItem {

		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie movie { get; set; }

	}

}