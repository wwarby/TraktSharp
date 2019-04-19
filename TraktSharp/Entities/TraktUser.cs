using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A Trakt user</summary>
	[Serializable]
	public class TraktUser {

		/// <summary>The user's username</summary>
		[JsonProperty(PropertyName = "username")]
		public string Username { get; set; }

		/// <summary><c>true</c> if the user has marked their account as private, otherwise <c>false</c></summary>
		[JsonProperty(PropertyName = "private")]
		public bool Private { get; set; }

		/// <summary>The user's full name</summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		/// <summary><c>true</c> if the user has a VIP account, otherwise <c>false</c></summary>
		[JsonProperty(PropertyName = "vip")]
		public bool Vip { get; set; }

		/// <summary>The UTC date when the user joined the Trakt service</summary>
		[JsonProperty(PropertyName = "joined_at")]
		public DateTime? JoinedAt { get; set; }

		/// <summary>The user's home location</summary>
		[JsonProperty(PropertyName = "location")]
		public string Location { get; set; }

		/// <summary>The user's profile description</summary>
		[JsonProperty(PropertyName = "about")]
		public string About { get; set; }

		/// <summary>The user's gender</summary>
		[JsonProperty(PropertyName = "gender")]
		public string Gender { get; set; }

		/// <summary>The user's age</summary>
		[JsonProperty(PropertyName = "age")]
		public int? Age { get; set; }

		/// <summary>A collection of images related to the user</summary>
		[JsonProperty(PropertyName = "images")]
		public TraktUserImages Images { get; set; }

	}

}