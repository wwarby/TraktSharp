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
		public string OlsonTimeZoneId { get; set; }

		[JsonIgnore]
		public TimeZoneInfo TimeZone {
			get { return string.IsNullOrEmpty(OlsonTimeZoneId) ? default(TimeZoneInfo) : TimeZoneHelper.FromOlsonTimeZoneId(OlsonTimeZoneId); }
		}

		//TODO: This implementation is a bit muddled and doesn't work properly. Revisit.
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
				if (nextAirDate == DateTime.MinValue || TimeZone == null) {
					return nextAirDate.ToLocalTime();
				}
				return TimeZoneInfo.ConvertTime(nextAirDate, TimeZone, TimeZoneInfo.Local).ToLocalTime();
			}
		}

	}

}