using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncLastActivitiesResponseComments {

		[JsonProperty(PropertyName = "liked_at")]
		public DateTime? LikedAt { get; set; }

	}

}