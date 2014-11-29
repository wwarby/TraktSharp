using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TraktSharp.Serialization {

	public class SkipDefaultPropertyValuesContractResolver : DefaultContractResolver {

		protected override JsonProperty CreateProperty(MemberInfo member,
			MemberSerialization memberSerialization) {
			var property = base.CreateProperty(member, memberSerialization);
			var memberProp = member as PropertyInfo;
			var memberField = member as FieldInfo;
			if (typeof(bool).IsAssignableFrom(property.PropertyType) || typeof(string).IsAssignableFrom(property.PropertyType)) {
				property.ShouldSerialize = obj => {
					var value = memberProp != null ? memberProp.GetValue(obj, null) : memberField != null ? memberField.GetValue(obj) : null;
					if (value is bool) { return (bool)value; }
					if (value is string) { return !string.IsNullOrWhiteSpace(value.ToString()); }
					return true;
				};
			}
			return property;
		}

	}

}