using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An error response for failed logins returned by the Trakt API</summary>
	[Serializable]
	public class TraktLoginErrorResponse {

		/// <summary>A message explaining the login failure</summary>
		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

	}

}