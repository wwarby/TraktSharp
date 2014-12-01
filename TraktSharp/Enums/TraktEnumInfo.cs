using System;
using System.Linq;

namespace TraktSharp.Enums {

	public class TraktEnumInfo : IEquatable<TraktEnumInfo> {

		public string Label { get; set; }

		public string Description { get; set; }

		public int Value { get; set; }

		public override string ToString() { return Description; }

		public override bool Equals(object obj) { return (obj is TraktEnumInfo) && Equals((TraktEnumInfo) obj); }

		public bool Equals(TraktEnumInfo other) { return Value == other.Value; }

		public override int GetHashCode() { return Value.GetHashCode(); }

		public static bool operator ==(TraktEnumInfo obj1, TraktEnumInfo obj2) { return obj1 != null && obj1.Equals(obj2); }

		public static bool operator !=(TraktEnumInfo obj1, TraktEnumInfo obj2) { return obj1 != null && !obj1.Equals(obj2); }

	}

}