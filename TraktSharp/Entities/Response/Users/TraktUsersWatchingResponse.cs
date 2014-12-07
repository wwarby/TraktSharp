using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response.Users {

	[Serializable]
	public class TraktUsersWatchingResponse {

		[JsonProperty(PropertyName = "expires_at")]
		public DateTime? ExpiresAt { get; set; }

		[JsonProperty(PropertyName = "started_at")]
		public DateTime? StartedAt { get; set; }

		[JsonIgnore]
		public TraktHistoryAction Action { get; set; }

		[JsonProperty(PropertyName = "action")]
		private string ActionString { get { return TraktEnumHelper.GetDescription(Action); } }

		[JsonIgnore]
		public TraktWatchingItemType Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string TypeString { get { return TraktEnumHelper.GetDescription(Type); } }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}