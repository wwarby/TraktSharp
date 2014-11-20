using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Shows {

	[Serializable]
	public class TraktShowsTranslationsResponseItem {

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

	}

}