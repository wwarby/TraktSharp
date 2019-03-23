using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response.Scrobble {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktScrobbleEpisodeResponse {

		/// <summary>The action associated with this scrobble</summary>
		[JsonIgnore]
		public TraktScrobbleAction Action { get; set; }

		[JsonProperty(PropertyName = "action")]
		private string ActionString => TraktEnumHelper.GetDescription(Action);

    /// <summary>The user's current playback progress through this item as a percentage between 0 and 100</summary>
		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		/// <summary>Indicators showing which connected social networks the action was published to</summary>
		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		/// <summary>The episode</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}