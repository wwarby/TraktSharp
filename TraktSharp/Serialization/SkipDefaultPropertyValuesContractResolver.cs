﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace TraktSharp.Serialization {
    internal class SkipDefaultPropertyValuesContractResolver : DefaultContractResolver {

        protected override JsonProperty CreateProperty(MemberInfo member,
            MemberSerialization memberSerialization) {
            var property = base.CreateProperty(member, memberSerialization);
            var memberProp = member as PropertyInfo;
            var memberField = member as FieldInfo;
            if (typeof(bool).GetTypeInfo().IsAssignableFrom(property.PropertyType.GetTypeInfo()) || typeof(string).GetTypeInfo().IsAssignableFrom(property.PropertyType.GetTypeInfo()))
            {
                property.ShouldSerialize = obj =>
                {
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