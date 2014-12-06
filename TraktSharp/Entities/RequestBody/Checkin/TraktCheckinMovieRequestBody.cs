using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities.RequestBody.Checkin {

	[Serializable]
	public class TraktCheckinMovieRequestBody {

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		[JsonProperty(PropertyName = "app_version")]
		public string AppVersion { get; set; }

		[JsonIgnore]
		public DateTime? AppDate { get; set; }

		[JsonProperty(PropertyName = "app_date")]
		private string AppDateString { get { return AppDate.ToTraktApiFormat(); } }

		[JsonProperty(PropertyName = "venue_id")]
		public string VenueId { get; set; }

		[JsonProperty(PropertyName = "venue_name")]
		public string VenueName { get; set; }

	}

}