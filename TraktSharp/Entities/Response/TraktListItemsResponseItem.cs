using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktListItemsResponseItem {

		[JsonProperty(PropertyName = "listed_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "season")]
		public TraktSeason Season { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}