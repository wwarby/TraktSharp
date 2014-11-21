using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	[Serializable]
	public class TraktMoviesTrendingResponseItem {

		[JsonProperty(PropertyName = "watchers")]
		public int? Watchers { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}