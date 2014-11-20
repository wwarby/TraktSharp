using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPerson {

		public TraktPerson() {
			Ids = new TraktPersonIds();
		}

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktPersonIds Ids { get; set; }

	}

}