using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeason {

		public TraktSeason() {
			Ids = new TraktSeasonIds();
		}

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktSeasonIds Ids { get; set; }

	}

}