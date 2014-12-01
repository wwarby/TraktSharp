using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {
	
	/// <summary>Describes whether a particular episode is completed in the context of a collection or watched history</summary>
	[Serializable]
	public class TraktEpisodeProgress {

		/// <summary>The episode number within the season to which it belongs</summary>
		[JsonProperty(PropertyName = "number")]
		public int? EpisodeNumber { get; set; }

		/// <summary><c>true</c> if the episode is completed, otherwise <c>false</c></summary>
		[JsonProperty(PropertyName = "completed")]
		public bool Completed { get; set; }

	}

}