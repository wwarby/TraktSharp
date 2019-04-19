using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An error response from the Trakt API</summary>
	[Serializable]
	public class TraktErrorResponse {

		/// <summary>The error category</summary>
		[JsonProperty(PropertyName = "error")]
		public string Error { get; set; }

		/// <summary>A descriptive message explaining the error</summary>
		[JsonProperty(PropertyName = "error_description")]
		public string Description { get; set; }

	}

}