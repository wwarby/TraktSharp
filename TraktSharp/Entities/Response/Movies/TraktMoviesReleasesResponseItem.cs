using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	[Serializable]
	public class TraktMoviesReleasesResponseItem {

		[JsonProperty(PropertyName = "certification")]
		public string Certification { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		[JsonProperty(PropertyName = "release_date")]
		public DateTime? ReleaseDate { get; set; }

	}

}