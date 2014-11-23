using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncResponseNotFound {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovie> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShow> Shows { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeason> Seasons { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

	}

}