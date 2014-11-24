using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktCollectionShowsResponseItemSeason {

		[JsonProperty(PropertyName = "number")]
		public int Number { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktCollectionShowsResponseItemEpisode> Episodes { get; set; }

	}

}