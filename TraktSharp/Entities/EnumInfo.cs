using System;
using System.Linq;

namespace TraktSharp.Entities {

	public class EnumInfo : IEquatable<EnumInfo> {

		public string Label { get; set; }

		public string Description { get; set; }

		public int Value { get; set; }

		public override string ToString() { return Description; }

		public override bool Equals(object obj) { return (obj is EnumInfo) && Equals((EnumInfo) obj); }

		public bool Equals(EnumInfo other) { return Value == other.Value; }

		public override int GetHashCode() { return Value.GetHashCode(); }

		public static bool operator ==(EnumInfo obj1, EnumInfo obj2) { return obj1 != null && obj1.Equals(obj2); }

		public static bool operator !=(EnumInfo obj1, EnumInfo obj2) { return obj1 != null && !obj1.Equals(obj2); }

	}

}