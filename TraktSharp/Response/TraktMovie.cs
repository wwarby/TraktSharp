using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktMovie {

		public TraktMovie() {
			Ids = new TraktMovieIds();
		}

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktMovieIds Ids { get; set; }

	}

}