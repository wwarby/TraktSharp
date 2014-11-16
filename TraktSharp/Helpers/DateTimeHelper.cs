using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TraktSharp.Helpers {

	public static class DateTimeHelper {

		public static DateTime NextOccurrenceOf(string day, string time, TimeZoneInfo timezone = null) {
			if (string.IsNullOrEmpty(day)) { throw new ArgumentException("Day not provided", "day"); }
			if (string.IsNullOrEmpty(day)) { throw new ArgumentException("Time not provided", "time"); }
			if (!Regex.IsMatch(time, @"\d{2}:\d{2}")) { throw new ArgumentException("Time must be in the 24 hour format hh:mm", "time"); }
			var now = DateTime.Now;
			if (timezone != null) {
				now = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezone);
			}
			var ret = new DateTime(now.Year, now.Month, now.Day, Int32.Parse(time.Substring(0, 2)), Int32.Parse(time.Substring(3, 2)), 0);
			while (!ret.ToString("dddd").Equals(day, StringComparison.InvariantCultureIgnoreCase)) { ret = ret.AddDays(1); }
			if (ret < now) { ret = ret.AddDays(7); }
			return ret;
		}

	}

}