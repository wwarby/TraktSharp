using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Helpers {

	public static class EnumsHelper {

		public static string GetDescription(Enum value) {
			var fi = value.GetType().GetField(value.ToString());
			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}

		public static Dictionary<string, EnumInfo> GetEnumInfo(Type type) {
			return type.GetFields().Where(v => v.FieldType == type).Select(v => {
				var ret = new EnumInfo { Label = v.Name, Value = (int)v.GetRawConstantValue() };
				var attributes = (DescriptionAttribute[])v.GetCustomAttributes(typeof(DescriptionAttribute), false);
				ret.Description = attributes.Length > 0 ? attributes[0].Description : v.Name;
				return ret;
			}).ToDictionary(v => v.Label);
		}

		public static T FromInt<T>(int value) { return (T)Enum.Parse(typeof(T), value.ToString(CultureInfo.InvariantCulture)); }

		public static T FromInt<T>(int value, T defaultValue) {
			try { return FromInt<T>(value); } catch { return defaultValue; }
		}

		public static T FromString<T>(string value) { return (T)Enum.Parse(typeof(T), value, true); }

		public static T FromString<T>(string value, T defaultValue) {
			try { return FromString<T>(value); } catch { return defaultValue; }
		}

		public static T FromDescription<T>(string value) {
			return (T)(object)GetEnumInfo(typeof(T)).Values.First(e => value.Equals(e.Description, StringComparison.InvariantCultureIgnoreCase)).Value;
		}

		public static T FromDescription<T>(string value, T defaultValue) {
			try { return FromDescription<T>(value); } catch { return defaultValue; }
		}

	}

}