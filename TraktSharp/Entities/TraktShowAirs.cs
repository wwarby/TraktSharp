using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowAirs {

		[JsonProperty(PropertyName = "day")]
		public string Day { get; set; }

		[JsonProperty(PropertyName = "time")]
		public string Time { get; set; }

		[JsonProperty(PropertyName = "timezone")]
		public string OlsonTimeZone { get; set; }

		[JsonIgnore]
		public TimeZoneInfo TimeZone { 
			get { return string.IsNullOrEmpty(OlsonTimeZone) ? default(TimeZoneInfo) : TimeZoneHelper.OlsonTimeZoneToTimeZoneInfo(OlsonTimeZone); }
		}

		[JsonIgnore]
		public DateTime NextAirDate {
			get {
				return !string.IsNullOrEmpty(Day) && !string.IsNullOrEmpty(Time) ? DateTimeHelper.NextOccurrenceOf(Day, Time, TimeZone) : DateTime.MinValue;
			}
		}

		[JsonIgnore]
		public DateTime NextAirDateLocal {
			get {
				var nextAirDate = NextAirDate;
				if (nextAirDate == DateTime.MinValue || TimeZone == null) { return nextAirDate.ToLocalTime(); }
				return TimeZoneInfo.ConvertTime(nextAirDate, TimeZone, TimeZoneInfo.Local).ToLocalTime();
			}
		}

	}

}