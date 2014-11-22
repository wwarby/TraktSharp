using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Auth {

	[Serializable]
	public class TraktAuthLoginRequestBody {

		[JsonProperty(PropertyName = "login")]
		public string Login { get; set; }

		[JsonProperty(PropertyName = "password")]
		public string Password { get; set; }

	}

}