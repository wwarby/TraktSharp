using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Settings on a Trakt user's account</summary>
	[Serializable]
	public class TraktUserSettings {

		/// <summary>The user</summary>
		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

		/// <summary>The user's account</summary>
		[JsonProperty(PropertyName = "account")]
		public TraktAccountSettings Account { get; set; }

		/// <summary>The user's social media connections</summary>
		[JsonProperty(PropertyName = "connections")]
		public TraktConnections Connections { get; set; }

		/// <summary>The user's social media sharing text templates</summary>
		[JsonProperty(PropertyName = "sharing_text")]
		public TraktSharingText SharingText { get; set; }

	}

}