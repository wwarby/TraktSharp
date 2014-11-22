using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Auth {

	[Serializable]
	public class TraktAuthLoginResponse {

		[JsonProperty(PropertyName = "token")]
		public string Token { get; set; }

	}

}