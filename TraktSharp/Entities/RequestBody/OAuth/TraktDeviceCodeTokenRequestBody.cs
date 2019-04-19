using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.OAuth {

	public class TraktDeviceCodeTokenRequestBody {

		/// <summary>Get this from your app settings</summary>
		[JsonProperty(PropertyName = "code")]
		public string Code { get; set; }

		/// <summary>Get this from your app settings</summary>
		[JsonProperty(PropertyName = "client_id")]
		public string ClientId { get; set; }

		/// <summary>Get this from your app settings</summary>
		[JsonProperty(PropertyName = "client_secret")]
		public string ClientSecret { get; set; }

	}

}