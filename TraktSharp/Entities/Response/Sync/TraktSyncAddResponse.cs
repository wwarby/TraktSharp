using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncAddResponse {

		[JsonProperty(PropertyName = "added")]
		public TraktSyncResponseCounts Added { get; set; }

		[JsonProperty(PropertyName = "existing")]
		public TraktSyncResponseCounts Existing { get; set; }

		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}