using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowWithRatingsMetadata : TraktShow {

		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		[JsonProperty(PropertyName = "rating")]
		new public Rating Rating { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public new IEnumerable<TraktSeasonWithRatingsMetadata> Seasons { get; set; }

	}

}