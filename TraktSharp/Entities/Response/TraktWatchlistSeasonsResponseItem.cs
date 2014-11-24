using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktWatchlistSeasonsResponseItem {

		[JsonProperty(PropertyName = "listed_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "season")]
		public TraktSeason Season { get; set; }

	}

}