using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncRatingsMoviesResponseItem {

		[JsonProperty(PropertyName = "rating")]
		public Rating Rating { get; set; }

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie movie { get; set; }

	}

}