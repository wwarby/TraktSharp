using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A request from one user to another to be followed</summary>
	[Serializable]
	public class TraktFollowRequest {

		/// <summary>The request ID</summary>
		[JsonProperty(PropertyName = "id")]
		public int? Id { get; set; }

		/// <summary>The UTC date when the request was made</summary>
		[JsonProperty(PropertyName = "requested_at")]
		public DateTime? RequestedAt { get; set; }

		/// <summary>The user who has requested to be followed</summary>
		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}