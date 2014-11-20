using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktErrorResponse {

		[JsonProperty(PropertyName = "error")]
		public string Error { get; set; }

		[JsonProperty(PropertyName = "error_description")]
		public string Description { get; set; }

	}

}