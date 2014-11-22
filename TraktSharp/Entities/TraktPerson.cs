using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPerson {

		public TraktPerson() { Ids = new TraktPersonIds(); }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktPersonIds Ids { get; set; }

		[JsonProperty(PropertyName = "images")]
		public TraktPersonImages Images { get; set; }

		[JsonProperty(PropertyName = "biography")]
		public string Biography { get; set; }

		[JsonProperty(PropertyName = "birthday")]
		public DateTime? Birthday { get; set; }

		[JsonProperty(PropertyName = "death")]
		public DateTime? Death { get; set; }

		[JsonProperty(PropertyName = "birthplace")]
		public string Birthplace { get; set; }

		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; set; }

	}

}