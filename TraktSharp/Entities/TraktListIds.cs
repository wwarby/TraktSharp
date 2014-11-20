using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktListIds {

		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

	}

}