using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktRemoveResponse {

		[JsonProperty(PropertyName = "deleted")]
		public TraktSyncResponseCounts Added { get; set; }

		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}