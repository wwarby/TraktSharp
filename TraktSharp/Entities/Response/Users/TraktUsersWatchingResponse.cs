using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response.Users {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktUsersWatchingResponse {

		/// <summary>The UTC date when the current checkin or scrobble expires</summary>
		[JsonProperty(PropertyName = "expires_at")]
		public DateTime? ExpiresAt { get; set; }

		/// <summary>The UTC date when the current checkin or scrobble was started</summary>
		[JsonProperty(PropertyName = "started_at")]
		public DateTime? StartedAt { get; set; }

		/// <summary>The action associated with the current checkin or scrobble</summary>
		[JsonIgnore]
		public TraktHistoryAction Action { get; set; }

		[JsonProperty(PropertyName = "action")]
		private string ActionString { get { return TraktEnumHelper.GetDescription(Action); } }

		/// <summary>The type of media item</summary>
		[JsonIgnore]
		public TraktWatchingItemType Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string TypeString { get { return TraktEnumHelper.GetDescription(Type); } }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>The episode</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}