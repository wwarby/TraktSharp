using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonWithCollectionMetadata : TraktSeason {

		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }


		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithCollectionMetadata> Episodes { get; set; }

	}

}