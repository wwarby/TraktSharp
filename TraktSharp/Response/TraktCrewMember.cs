using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktCrewMember {

		public TraktCrewMember() {
			Person = new TraktPerson();
		}

		[JsonProperty(PropertyName = "job")]
		public string Job { get; set; }

		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

	}

}