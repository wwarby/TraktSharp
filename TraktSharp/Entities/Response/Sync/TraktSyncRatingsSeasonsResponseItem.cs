using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncRatingsSeasonsResponseItem {

		[JsonProperty(PropertyName = "rating")]
		public Rating Rating { get; set; }

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "season")]
		public TraktSeason Season { get; set; }

	}

}