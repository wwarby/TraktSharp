using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	[Serializable]
	public class TraktUsersFriendsResponseItem {

		[JsonProperty(PropertyName = "friends_at")]
		public DateTime? FriendsAt { get; set; }

		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}