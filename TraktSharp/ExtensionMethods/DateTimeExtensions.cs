using System;

namespace TraktSharp.ExtensionMethods {

	internal static class DateTimeExtensions {

		internal static DateTime Min(this DateTime value, DateTime? otherDate) => value.Min(otherDate.GetValueOrDefault());

		internal static DateTime Min(this DateTime? value, DateTime otherDate) => otherDate.Min(value.GetValueOrDefault());

		internal static DateTime Min(this DateTime? value, DateTime? otherDate) => value.GetValueOrDefault().Min(otherDate.GetValueOrDefault());

		internal static DateTime Min(this DateTime value, DateTime otherDate) => value < otherDate ? value : otherDate;

		internal static DateTime Max(this DateTime value, DateTime? otherDate) => value.Max(otherDate.GetValueOrDefault());

		internal static DateTime Max(this DateTime? value, DateTime otherDate) => otherDate.Max(value.GetValueOrDefault());

		internal static DateTime Max(this DateTime? value, DateTime? otherDate) => value.GetValueOrDefault().Max(otherDate.GetValueOrDefault());

		internal static DateTime Max(this DateTime value, DateTime otherDate) => value > otherDate ? value : otherDate;

		internal static string ToTraktApiFormat(this DateTime value) => value.ToString("yyyy-MM-dd");

		internal static string ToTraktApiFormat(this DateTime? value) => !value.HasValue ? string.Empty : value.Value.ToTraktApiFormat();

		internal static int YearsBetween(this DateTime value, DateTime? otherDate) => value.YearsBetween(otherDate.GetValueOrDefault());

		internal static int YearsBetween(this DateTime? value, DateTime otherDate) => otherDate.YearsBetween(value.GetValueOrDefault());

		internal static int YearsBetween(this DateTime? value, DateTime? otherDate) => value.GetValueOrDefault().YearsBetween(otherDate.GetValueOrDefault());

		internal static int YearsBetween(this DateTime value, DateTime otherDate) => (new DateTime(1, 1, 1) + (value.Max(otherDate) - value.Min(otherDate))).Year - 1;

	}

}