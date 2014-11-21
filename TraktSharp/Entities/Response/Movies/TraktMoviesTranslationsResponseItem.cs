using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	[Serializable]
	public class TraktMoviesTranslationsResponseItem {

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		[JsonProperty(PropertyName = "tagline")]
		public string Tagline { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

	}

}