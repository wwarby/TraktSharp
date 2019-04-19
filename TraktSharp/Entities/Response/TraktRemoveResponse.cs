using System;
using Newtonsoft.Json;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktRemoveResponse {

		/// <summary>The numbers of items that were removed</summary>
		[JsonProperty(PropertyName = "deleted")]
		public TraktSyncResponseCounts Deleted { get; set; }

		/// <summary>The items that were requested to be removed but which were not found</summary>
		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}