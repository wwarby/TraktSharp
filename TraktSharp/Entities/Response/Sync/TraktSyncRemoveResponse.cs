using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncRemoveResponse {

		[JsonProperty(PropertyName = "deleted")]
		public TraktSyncResponseCounts Added { get; set; }

		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}