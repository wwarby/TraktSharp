using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities.RequestBody.Scrobble {

	/// <summary>Request body parameters for an episode scrobble request</summary>
	[Serializable]
	public class TraktScrobbleEpisodeRequestBody {

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>The episode</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		/// <summary>The user's current playback progress through this item as a percentage between 0 and 100</summary>
		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		/// <summary>Version number of the app</summary>
		[JsonProperty(PropertyName = "app_version")]
		public string AppVersion { get; set; }

		/// <summary>Build date of the app</summary>
		[JsonIgnore]
		public DateTime? AppDate { get; set; }

		[JsonProperty(PropertyName = "app_date")]
		private string AppDateString { get { return AppDate.ToTraktApiFormat(); } }

	}

}