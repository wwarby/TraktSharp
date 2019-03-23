using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Holds metadata about an enumeration member</summary>
	public class TraktEnumMemberInfo : IEquatable<TraktEnumMemberInfo> {

		/// <summary>The text label for the enumeration member</summary>
		public string Label { get; set; }

		/// <summary>The description (from <see cref="DescriptionAttribute"/>) of the enumeration member</summary>
		public string Description { get; set; }

		/// <summary>The numeric value of the enumeration member</summary>
		public int Value { get; set; }

		/// <summary>Formats the enumeration member metadata as a string, using the first non-null result from description, label or value</summary>
		/// <returns>A string representation of the enumeration member metadata</returns>
		public override string ToString() => !string.IsNullOrEmpty(Description) ? Description : string.IsNullOrEmpty(Label) ? Label : Value.ToString(CultureInfo.InvariantCulture);

		/// <summary>Determines whether two object instances are equal</summary>
		/// <param name="obj">The object to compare with the current object</param>
		/// <returns><c>true</c> if the specified object is equal to the current object, otherwise <c>false</c></returns>
		public override bool Equals(object obj) => (obj is TraktEnumMemberInfo memberInfo) && Equals(memberInfo);

		/// <summary>Determines whether two object instances are equal</summary>
		/// <param name="obj">The <see cref="TraktEnumMemberInfo"/> to compare with the current object</param>
		/// <returns><c>true</c> if the specified <see cref="TraktEnumMemberInfo"/> is equal to the current object, otherwise <c>false</c></returns>
		public bool Equals(TraktEnumMemberInfo obj) => Value == obj.Value;

		/// <summary>Overrides the default hash function to use the enumeration member <see cref="Value"/> for the the hashcode</summary>
		/// <returns>A hash code for the current object</returns>
		public override int GetHashCode() => Value.GetHashCode();

		/// <summary>Provides an implementation of the equality operator between two <see cref="TraktEnumMemberInfo"/> instances</summary>
		/// <param name="obj1">The first <see cref="TraktEnumMemberInfo"/> instance</param>
		/// <param name="obj2">The second <see cref="TraktEnumMemberInfo"/> instance</param>
		/// <returns><c>true</c> if the <see cref="TraktEnumMemberInfo"/> instances are equal, otherwise <c>false</c></returns>
		public static bool operator ==(TraktEnumMemberInfo obj1, TraktEnumMemberInfo obj2) => obj1 != null && obj1.Equals(obj2);

		/// <summary>Provides an implementation of the inequality operator between two <see cref="TraktEnumMemberInfo"/> instances</summary>
		/// <param name="obj1">The first <see cref="TraktEnumMemberInfo"/> instance</param>
		/// <param name="obj2">The second <see cref="TraktEnumMemberInfo"/> instance</param>
		/// <returns><c>true</c> if the <see cref="TraktEnumMemberInfo"/> instances are not equal, otherwise <c>false</c></returns>
		public static bool operator !=(TraktEnumMemberInfo obj1, TraktEnumMemberInfo obj2) => obj1 != null && !obj1.Equals(obj2);

	}

}