using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktUser {

		[JsonProperty(PropertyName = "username")]
		public string Username { get; set; }

		[JsonProperty(PropertyName = "private")]
		public bool Private { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "vip")]
		public bool VIP { get; set; }

	}

}