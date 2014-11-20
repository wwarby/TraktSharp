using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowProgress {

		public TraktShowProgress() {
			Seasons = new List<TraktSeasonProgress>();
			NextEpisode = new TraktEpisode();
		}

		[JsonProperty(PropertyName = "aired")]
		public int? Aired { get; set; }

		[JsonProperty(PropertyName = "completed")]
		public int? Completed { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeasonProgress> Seasons { get; set; }
		
		[JsonProperty(PropertyName = "next_episode")]
		public TraktEpisode NextEpisode { get; set; }

	}

}