using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response.Users {
	
	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktUsersHistoryEpisodesResponseItem {

		/// <summary>The UTC date when the item was watched</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTimeOffset? WatchedAt { get; set; }

		/// <summary>The action that generated this history item</summary>
		[JsonIgnore]
		public TraktHistoryAction Action { get; set; }

		[JsonProperty(PropertyName = "action")]
		private string ActionString { get { return TraktEnumHelper.GetDescription(Action); } }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>The episode</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}