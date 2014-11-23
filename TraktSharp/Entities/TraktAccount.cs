using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktAccount {

		[JsonProperty(PropertyName = "timezone")]
		public string OlsonTimeZoneId { get; set; }

		[JsonProperty(PropertyName = "cover_image")]
		public string CoverImage { get; set; }

	}

}