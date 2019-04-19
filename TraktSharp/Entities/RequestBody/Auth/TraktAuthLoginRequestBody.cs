using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Auth {

	/// <summary>Request body parameters for a login request</summary>
	[Serializable]
	public class TraktAuthLoginRequestBody {

		/// <summary>The login username</summary>
		[JsonProperty(PropertyName = "login")]
		public string Login { get; set; }

		/// <summary>The password</summary>
		[JsonProperty(PropertyName = "password")]
		public string Password { get; set; }

	}

}