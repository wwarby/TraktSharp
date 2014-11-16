using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktMSeason {

		public TraktMSeason() {
			Ids = new TraktSeasonIds();
		}

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktSeasonIds Ids { get; set; }

	}

}