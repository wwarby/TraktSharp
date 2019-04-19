using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktUsersFollowResponse {

		/// <summary>The UTC date when the follow request was made</summary>
		[JsonProperty(PropertyName = "followed_at")]
		public DateTime? FollowedAt { get; set; }

		/// <summary>The user who is being followed</summary>
		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}