using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace TraktSharp.Helpers {

	/// <summary>A helper class for interacting with enumeration members</summary>
	public static class TraktEnumHelper {

		/// <summary>Get the description (from <see cref="DescriptionAttribute"/>) for the specified enumeration value</summary>
		/// <param name="value">The enumeration value</param>
		/// <returns>The description text</returns>
		public static string GetDescription(Enum value) {
            var descriptionattr = value.GetAttribute<DescriptionAttribute>();
            return descriptionattr != null ? descriptionattr.Description : value.ToString();
		}

		/// <summary>Get the text label for the specified enumeration value</summary>
		/// <param name="value">The enumeration value</param>
		/// <returns>The text label</returns>
		public static string GetLabel(Enum value) => value.ToString();

		/// <summary>
        /// Gets a List of Labels for the current type.
        /// </summary>
        /// <param name="type">Enum Type.</param>
        /// <returns>Labels.</returns>
        public static IEnumerable<string> GetEnumLabels(Type type) => Enum.GetNames(type);

		/// <summary>
        /// Gets a list of Descriptions for the current Type.
        /// </summary>
        /// <param name="type">Enum Type.</param>
        /// <returns>Descriptions.</returns>
        public static IEnumerable<string> GetEnumDescriptions(Type type)
        {
            var result = new List<string>();
            var enumArray = Enum.GetValues(type);
            foreach(var item in enumArray)
            {
                var description = GetDescription((Enum)item);
                result.Add(description);
            }
            return result;
        }

		/// <summary>Parses an integer to a specified enumeration type</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The enumeration member value</param>
		/// <returns>An instance of the specified enumeration type, or throws an exception if <paramref name="value"/> is not a valid value for the specified enumeration type</returns>
		public static T FromInt<T>(int value) => (T)Enum.Parse(typeof(T), value.ToString(CultureInfo.InvariantCulture));

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
		public static T FromLabel<T>(string value) => (T)Enum.Parse(typeof(T), value, true);

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
		public static T FromDescription<T>(string value) => FromDescription(value, default(T));

		/// <summary>Parses a description (from <see cref="DescriptionAttribute"/>) to a specified enumeration type, allowing silent fallback to a default value of parsing fails</summary>
		/// <typeparam name="T">The enumeration type</typeparam>
		/// <param name="value">The description value</param>
		/// <param name="defaultValue">The value to be returned if <paramref name="value"/> is not a valid description for the specified enumeration type</param>
		/// <returns>An instance of the specified enumeration type</returns>
		public static T FromDescription<T>(string value, T defaultValue) {
            var enumType = typeof(T);
            var values = Enum.GetValues(enumType);
            for (var i = 0; i < values.Length; i++)
            {
                if (value == ((Enum)Enum.ToObject(enumType, i)).GetAttribute<DescriptionAttribute>().Description) {
					return (T)(object)i;
				}
			}
            return defaultValue;
        }

        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute =>
			enumValue
				.GetType()
				.GetTypeInfo()
				.GetDeclaredField(enumValue.ToString())
				.GetCustomAttribute<T>();

	}
}