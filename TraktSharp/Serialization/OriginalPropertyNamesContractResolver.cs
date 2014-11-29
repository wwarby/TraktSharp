using System;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace TraktSharp.Serialization {

	public class OriginalPropertyNamesContractResolver : DefaultContractResolver {

		protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, Newtonsoft.Json.MemberSerialization memberSerialization) {
			var ret = base.CreateProperty(member, memberSerialization);
			ret.PropertyName = ret.UnderlyingName;
			return ret;
		}

	}

}