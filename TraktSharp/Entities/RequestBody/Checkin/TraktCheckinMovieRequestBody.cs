using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Entities.RequestBody.Checkin {

	/// <summary>Request body parameters for a movie checkin request</summary>
	[Serializable]
	public class TraktCheckinMovieRequestBody {

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		/// <summary>Control sharing to any connected social networks</summary>
		[JsonProperty(PropertyName = "sharing")]
		public TraktSharing Sharing { get; set; }

		/// <summary>Message used for sharing. If not sent, it will use the watching string in the user settings.</summary>
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		/// <summary>Version number of the app</summary>
		[JsonProperty(PropertyName = "app_version")]
		public string AppVersion { get; set; }

		/// <summary>Build date of the app</summary>
		[JsonIgnore]
		public DateTime? AppDate { get; set; }

		[JsonProperty(PropertyName = "app_date")]
		private string AppDateString => AppDate.ToTraktApiFormat();

		/// <summary>Foursquare venue ID</summary>
		[JsonProperty(PropertyName = "venue_id")]
		public string VenueId { get; set; }

		/// <summary>Foursquare venue name</summary>
		[JsonProperty(PropertyName = "venue_name")]
		public string VenueName { get; set; }

	}

}