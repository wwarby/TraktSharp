using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities.RequestBody.Checkin {

	[Serializable]
	public class TraktCheckinEpisodeRequestBody {

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharingOptions Sharing { get; set; }

		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		[JsonProperty(PropertyName = "app_version")]
		public string AppVersion { get; set; }

		[JsonProperty(PropertyName = "app_date")]
		public string AppDateString {
			get { return AppDate.ToTraktApiFormat(); }
		}

		[JsonIgnore]
		public DateTime? AppDate { get; set; }

		[JsonProperty(PropertyName = "venue_id")]
		public string VenueId { get; set; }

		[JsonProperty(PropertyName = "venue_name")]
		public string VenueName { get; set; }

	}

}