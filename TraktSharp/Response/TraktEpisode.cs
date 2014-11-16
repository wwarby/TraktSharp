using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktEpisode {

		public TraktEpisode() {
			Title = string.Empty;
			Ids = new TraktEpisodeIds();
		}

		[JsonProperty(PropertyName = "season")]
		public int? Season { get; set; }

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktEpisodeIds Ids { get; set; }

	}

}