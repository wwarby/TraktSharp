using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Auth {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktAuthLoginResponse {

		/// <summary>The authentication token</summary>
		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }

	}

}