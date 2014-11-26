using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktAddResponse {

		[JsonProperty(PropertyName = "added")]
		public TraktSyncResponseCounts Added { get; set; }

		[JsonProperty(PropertyName = "existing")]
		public TraktSyncResponseCounts Existing { get; set; }

		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}