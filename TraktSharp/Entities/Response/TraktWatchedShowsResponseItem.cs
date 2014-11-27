using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktWatchedShowsResponseItem {

		[JsonProperty(PropertyName = "plays")]
		public int? Plays { get; set; }

		[JsonProperty(PropertyName = "last_watched_at")]
		public DateTime? LastWatchedAt { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktWatchedShowsResponseItemSeason> Seasons { get; set; }

	}

}