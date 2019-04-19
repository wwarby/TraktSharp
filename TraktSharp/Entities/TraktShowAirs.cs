using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	/// <summary>The air time for a show</summary>
	[Serializable]
	public class TraktShowAirs {

		/// <summary>The day of the week on which the show airs</summary>
		[JsonProperty(PropertyName = "day")]
		public string Day { get; set; }

		/// <summary>The time of day at which the show airs</summary>
		[JsonProperty(PropertyName = "time")]
		public string Time { get; set; }

		/// <summary>The Olson time zone ID for the location in which the show airs (<see cref="Day"/> and <see cref="Time"/> are relative to this time zone)</summary>
		[JsonProperty(PropertyName = "timezone")]
		public string OlsonTimeZoneId { get; set; }

		/// <summary>The time zone for the location in which the show airs (derived from <see cref="OlsonTimeZoneId"/>)</summary>
		[JsonIgnore]
		public TimeZoneInfo TimeZone => !string.IsNullOrEmpty(OlsonTimeZoneId) ? TraktTimeZoneHelper.FromOlsonTimeZoneId(OlsonTimeZoneId) : default;

		/// <summary>The day of the week on which the show airs in local time</summary>
		[JsonIgnore]
		public string LocalDay {
			get {
				if (string.IsNullOrEmpty(Day) || string.IsNullOrEmpty(Time) || !Regex.IsMatch(Time, @"\d{2}:\d{2}") || TimeZone == null) { return string.Empty; }
				var days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
				var dayIndex = days.IndexOf(Day);
				var hours = int.Parse(Time.Substring(0, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes / 60);
				var minutes = int.Parse(Time.Substring(3, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes % 60);
				if (minutes > 60) {
					hours++;
				} else if (minutes < 0) {
					hours--;
				}
				if (hours < 0) { return dayIndex > 0 ? days[dayIndex - 1] : days.Last(); }
				if (hours > 24) { return dayIndex < 6 ? days[dayIndex + 1] : days.First(); }
				return Day;
			}
		}

		/// <summary>The day of the week on which the show airs in local time</summary>
		[JsonIgnore]
		public string LocalTime {
			get {
				if (string.IsNullOrEmpty(Day) || string.IsNullOrEmpty(Time) || !Regex.IsMatch(Time, @"\d{2}:\d{2}") || TimeZone == null) { return string.Empty; }
				var hours = int.Parse(Time.Substring(0, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes / 60);
				var minutes = int.Parse(Time.Substring(3, 2)) + (int)Math.Floor(TimeZoneOffsetMinutes % 60);
				if (minutes > 60) {
					minutes -= 60;
					hours++;
				} else if (minutes < 0) {
					minutes += 60;
					hours--;
				}
				if (hours < 0) { hours += 24; }
				if (hours > 24) { hours -= 24; }
				return $"{hours:00}:{minutes:00}";
			}
		}

		private double TimeZoneOffsetMinutes => TimeZone == null ? 0 : TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes - TimeZone.GetUtcOffset(DateTime.Now).TotalMinutes;

	}

}