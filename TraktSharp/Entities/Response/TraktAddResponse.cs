using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktAddResponse {

		/// <summary>The numbers of items that were added</summary>
		[JsonProperty(PropertyName = "added")]
		public TraktSyncResponseCounts Added { get; set; }

		/// <summary>The numbers of items that were updated</summary>
		[JsonProperty(PropertyName = "updated")]
		public TraktSyncResponseCounts Updated { get; set; }

		/// <summary>The numbers of items that were unchanged because they already existed</summary>
		[JsonProperty(PropertyName = "existing")]
		public TraktSyncResponseCounts Existing { get; set; }

		/// <summary>The items that were requested to be added but which were not found</summary>
		[JsonProperty(PropertyName = "not_found")]
		public TraktSyncResponseNotFound NotFound { get; set; }

	}

}