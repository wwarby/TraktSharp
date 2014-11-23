using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeason {

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktSeasonIds Ids { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

	}

}