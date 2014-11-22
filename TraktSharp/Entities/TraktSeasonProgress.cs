using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonProgress {

		public TraktSeasonProgress() { Episodes = new List<TraktEpisodeProgress>(); }

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "aired")]
		public int? Aired { get; set; }

		[JsonProperty(PropertyName = "completed")]
		public int? Completed { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeProgress> Episodes { get; set; }

	}

}