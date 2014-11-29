using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktLoginErrorResponse {

		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

	}

}