using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktFollowRequest {

		[JsonProperty(PropertyName = "id")]
		public int? Id { get; set; }

		[JsonProperty(PropertyName = "requested_at")]
		public DateTime? RequestedAt { get; set; }

		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}