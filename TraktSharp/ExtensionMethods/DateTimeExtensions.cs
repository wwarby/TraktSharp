using System;
using System.Linq;

namespace TraktSharp.ExtensionMethods {

	internal static class DateTimeExtensions {

		internal static DateTime Min(this DateTime value, DateTime? otherDate) { return value.Min(otherDate.GetValueOrDefault()); }

		internal static DateTime Min(this DateTime? value, DateTime otherDate) { return otherDate.Min(value.GetValueOrDefault()); }

		internal static DateTime Min(this DateTime? value, DateTime? otherDate) { return value.GetValueOrDefault().Min(otherDate.GetValueOrDefault()); }

		internal static DateTime Min(this DateTime value, DateTime otherDate) { return value < otherDate ? value : otherDate; }

		internal static DateTime Max(this DateTime value, DateTime? otherDate) { return value.Max(otherDate.GetValueOrDefault()); }

		internal static DateTime Max(this DateTime? value, DateTime otherDate) { return otherDate.Max(value.GetValueOrDefault()); }

		internal static DateTime Max(this DateTime? value, DateTime? otherDate) { return value.GetValueOrDefault().Max(otherDate.GetValueOrDefault()); }

		internal static DateTime Max(this DateTime value, DateTime otherDate) { return value > otherDate ? value : otherDate; }

		internal static string ToTraktApiFormat(this DateTime value) { return value.ToString("yyyy-MM-dd"); }

		internal static string ToTraktApiFormat(this DateTime? value) { return !value.HasValue ? string.Empty : value.Value.ToTraktApiFormat(); }

		internal static int YearsBetween(this DateTime value, DateTime? otherDate) { return value.YearsBetween(otherDate.GetValueOrDefault()); }

		internal static int YearsBetween(this DateTime? value, DateTime otherDate) { return otherDate.YearsBetween(value.GetValueOrDefault()); }

		internal static int YearsBetween(this DateTime? value, DateTime? otherDate) { return value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault()); }

		internal static int YearsBetween(this DateTime value, DateTime otherDate) { return (new DateTime(1, 1, 1) + (value.Max(otherDate) - value.Min(otherDate))).Year - 1; }

	}

}