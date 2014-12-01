using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktCollectionMoviesResponseItem {

		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}