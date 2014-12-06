using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities.RequestBody.Scrobble {

	[Serializable]
	public class TraktScrobbleEpisodeRequestBody {

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "progress")]
		public float Progress { get; set; }

		[JsonProperty(PropertyName = "app_version")]
		public string AppVersion { get; set; }

		[JsonIgnore]
		public DateTime? AppDate { get; set; }

		[JsonProperty(PropertyName = "app_date")]
		private string AppDateString { get { return AppDate.ToTraktApiFormat(); } }

	}

}