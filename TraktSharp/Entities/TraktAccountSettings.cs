using Newtonsoft.Json;
using System;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	/// <summary>Settings for a user's account</summary>
	[Serializable]
	public class TraktAccountSettings {

		/// <summary>The user's timezone represented in the form of an Olson timezone ID string</summary>
		[JsonProperty(PropertyName = "timezone")]
		public string OlsonTimeZoneId { get; set; }

		/// <summary>The user's timezone represented in the form of a <see cref="TimeZoneInfo"/> instance (derived from <see cref="OlsonTimeZoneId"/>)</summary>
		[JsonIgnore]
		public TimeZoneInfo TimeZone => !string.IsNullOrEmpty(OlsonTimeZoneId) ? TraktTimeZoneHelper.FromOlsonTimeZoneId(OlsonTimeZoneId) : default;

    /// <summary>A cover image for the user's account</summary>
		[JsonProperty(PropertyName = "cover_image")]
		public string CoverImage { get; set; }

	}

}