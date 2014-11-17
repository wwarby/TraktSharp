using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktImageSet {

		[JsonProperty(PropertyName = "full")]
		public string Full { get; set; }

		[JsonProperty(PropertyName = "medium")]
		public string Medium { get; set; }
		
		[JsonProperty(PropertyName = "thumb")]
		public string Thumb { get; set; }

	}

}