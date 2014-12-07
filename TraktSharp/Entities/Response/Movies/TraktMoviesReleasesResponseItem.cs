using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesReleasesResponseItem {

		/// <summary>The certification associated with this release</summary>
		[JsonProperty(PropertyName = "certification")]
		public string Certification { get; set; }

		/// <summary>The country in which this release date is applicable in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

		/// <summary>The release date</summary>
		[JsonProperty(PropertyName = "release_date")]
		public DateTime? ReleaseDate { get; set; }

	}

}