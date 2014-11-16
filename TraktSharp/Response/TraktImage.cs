using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	public class TraktImage {

		[JsonProperty(PropertyName = "full")]
		public string Full { get; set; }

	}

}