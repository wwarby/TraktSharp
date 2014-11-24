using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktRatingsShowsResponseItem {

		[JsonProperty(PropertyName = "rating")]
		public Rating Rating { get; set; }

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}