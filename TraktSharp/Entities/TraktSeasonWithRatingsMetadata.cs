using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonWithRatingsMetadata : TraktSeason {

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithRatingsMetadata> Episodes { get; set; }

	}

}