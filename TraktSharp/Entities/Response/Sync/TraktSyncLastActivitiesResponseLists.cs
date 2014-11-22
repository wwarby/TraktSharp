using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncLastActivitiesResponseLists {

		[JsonProperty(PropertyName = "liked_at")]
		public DateTime? LikedAt { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

	}

}