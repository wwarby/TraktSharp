using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using TraktSharp.Enums;

namespace TraktSharp.Helpers {

	/// <summary>A helper class for interacting with enumeration members</summary>
	public static class TraktEnumHelper {

		/// <summary>Get the description (from <see cref="DescriptionAttribute"/>) for the specified enumeration value</summary>
		/// <param name="value">The enumeration value</param>
		/// <returns>The description text</returns>
		public static string GetDescription(Enum value) {
			var fi = value.GetType().GetField(value.ToString());
			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}

		/// <summary>Get the text label for the specified enumeration value</summary>
		/// <param name="value">The enumeration value</param>
		/// <returns>The text label</returns>
		public static string GetLabel(Enum value) {
			return value.ToString();
		}

		/// <summary>Gets metadata about the members of an enumeration</summary>
		/// <param name="type">The enumeration type</param>
		/// <returns>A collection of <see cref="TraktEnumMemberInfo"/> instances describing the enumeration members</returns>
		public static Dictionary<string, TraktEnumMemberInfo> GetEnumMembers(Type type) {
			return type.GetFields().Where(v => v.FieldType == type).Select(v => {
				var ret = new TraktEnumMemberInfo { Label = v.Name, Value = (int)v.GetRawConstantValue() };
				var attributes = (DescriptionAttribute[])v.GetCustomAttributes(typeof(DescriptionAttribute), false);
				ret.Description = attributes.Length > 0 ? attributes[0].Description : v.Name;
				return ret;
			}).ToDictionary(v => v.Label);
		}

		/// <summary>Parses an integer to a specified enumeration type</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The enumeration member value</param>
		/// <returns>An instance of the specified enumeration type, or throws an exception if <paramref name="value"/> is not a valid value for the specified enumeration type</returns>
		public static T FromInt<T>(int value) { return (T)Enum.Parse(typeof(T), value.ToString(CultureInfo.InvariantCulture)); }

		/// <summary>Parses an integer to a specified enumeration type, allowing silent fallback to a default value of parsing fails</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The enumeration member value</param>
		/// <param name="defaultValue">The value to be returned if <paramref name="value"/> is not a valid value for the specified enumeration type</param>
		/// <returns>An instance of the specified enumeration type</returns>
		public static T FromInt<T>(int value, T defaultValue) {
			try {
				return FromInt<T>(value);
			} catch {
				return defaultValue;
			}
		}

		/// <summary>Parses a text label to a specified enumeration type</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The text label value</param>
		/// <returns>An instance of the specified enumeration type, or throws an exception if <paramref name="value"/> is not a valid text label for the specified enumeration type</returns>
		public static T FromLabel<T>(string value) { return (T)Enum.Parse(typeof(T), value, true); }

		/// <summary>Parses a text label to a specified enumeration type, allowing silent fallback to a default value of parsing fails</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The text label value</param>
		/// <param name="defaultValue">The value to be returned if <paramref name="value"/> is not a valid text label for the specified enumeration type</param>
		/// <returns>An instance of the specified enumeration type</returns>
		public static T FromLabel<T>(string value, T defaultValue) {
			try {
				return FromLabel<T>(value);
			} catch {
				return defaultValue;
			}
		}

		/// <summary>Parses a description (from <see cref="DescriptionAttribute"/>) to a specified enumeration type</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The description value</param>
		/// <returns>An instance of the specified enumeration type, or throws an exception if <paramref name="value"/> is not a valid description for the specified enumeration type</returns>
		public static T FromDescription<T>(string value) { return (T)(object)GetEnumMembers(typeof(T)).Values.First(e => value.Equals(e.Description, StringComparison.InvariantCultureIgnoreCase)).Value; }

		/// <summary>Parses a description (from <see cref="DescriptionAttribute"/>) to a specified enumeration type, allowing silent fallback to a default value of parsing fails</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The description value</param>
		/// <param name="defaultValue">The value to be returned if <paramref name="value"/> is not a valid description for the specified enumeration type</param>
		/// <returns>An instance of the specified enumeration type</returns>
		public static T FromDescription<T>(string value, T defaultValue) {
			try {
				return FromDescription<T>(value);
			} catch {
				return defaultValue;
			}
		}

	}

}