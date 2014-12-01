using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktRatingsMoviesResponseItem {

		[JsonProperty(PropertyName = "rating")]
		public Rating Rating { get; set; }

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}