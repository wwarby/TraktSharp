using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	[Serializable]
	public class TraktUsersFollowResponseItem {

		[JsonProperty(PropertyName = "followed_at")]
		public DateTime? FollowedAt { get; set; }

		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}