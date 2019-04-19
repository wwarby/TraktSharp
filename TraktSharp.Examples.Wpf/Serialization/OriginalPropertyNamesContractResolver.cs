using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TraktSharp.Examples.Wpf.Serialization {

	internal class OriginalPropertyNamesContractResolver : DefaultContractResolver {

		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
			var ret = base.CreateProperty(member, memberSerialization);
			ret.PropertyName = ret.UnderlyingName;
			return ret;
		}

	}

}