using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSearchResult {

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		[JsonProperty(PropertyName = "score")]
		public decimal? Score { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

		[JsonProperty(PropertyName = "list")]
		public TraktList List { get; set; }

	}

}