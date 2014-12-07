using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktUsersFriendsResponseItem {

		/// <summary>The UTC date when the friendship was established</summary>
		[JsonProperty(PropertyName = "friends_at")]
		public DateTime? FriendsAt { get; set; }

		/// <summary>The user with whom the friendship is established</summary>
		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}