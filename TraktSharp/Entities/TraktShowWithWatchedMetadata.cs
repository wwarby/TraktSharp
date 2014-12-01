using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A show with metadata related to a user's watched status in regard to that show</summary>
	[Serializable]
	public class TraktShowWithWatchedMetadata : TraktShow {

		/// <summary>The UTC date when the user watched the show</summary>
		[JsonProperty(PropertyName = "watched_at")]
		public DateTime? WatchedAt { get; set; }

		/// <summary>A collection of seasons with metadata related to a user's watched status in regard to each season</summary>
		[JsonProperty(PropertyName = "seasons")]
		public new IEnumerable<TraktSeasonWithWatchedMetadata> Seasons { get; set; }

	}

}