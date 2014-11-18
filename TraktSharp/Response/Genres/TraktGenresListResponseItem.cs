using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response.Genres {

	[Serializable]
	public class TraktGenresListResponseItem {

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

	}

}