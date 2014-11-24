using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktCollectionShowsResponseItemEpisode {

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

	}

}