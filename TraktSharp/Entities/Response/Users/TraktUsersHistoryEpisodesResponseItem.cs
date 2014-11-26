using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Users {

	[Serializable]
	public class TraktUsersHistoryEpisodesResponseItem {

		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		[JsonProperty(PropertyName = "action")]
		public string Action { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}