using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	[Serializable]
	public class TraktMoviesAliasesResponseItem {

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "country")]
		public string Country { get; set; }

	}

}