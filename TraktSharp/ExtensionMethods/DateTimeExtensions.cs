using System;
using System.Linq;

namespace TraktSharp.ExtensionMethods {

	public static class DateTimeExtensions {

		public static string ToTraktApiFormat(this DateTime value) { return value.ToString("yyyy-MM-dd"); }

		public static string ToTraktApiFormat(this DateTime? value) { return !value.HasValue ? string.Empty : value.Value.ToTraktApiFormat(); }

	}

}