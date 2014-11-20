using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktCastMember {

		public TraktCastMember() {
			Person = new TraktPerson();
		}

		[JsonProperty(PropertyName = "character")]
		public string Character { get; set; }

		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

	}

}