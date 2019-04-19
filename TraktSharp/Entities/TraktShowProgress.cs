using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Describes whether a particular show is completed in the context of a collection or watched history</summary>
	[Serializable]
	public class TraktShowProgress {

		/// <summary>The number of seasons for which at least one episode has been aired to date</summary>
		[JsonProperty(PropertyName = "aired")]
		public int? AiredCount { get; set; }

		/// <summary>
		///     <c>true</c> if all the aired episodes in this all the seasons of the show are completed, otherwise
		///     <c>false</c>
		/// </summary>
		[JsonProperty(PropertyName = "completed")]
		public int? Completed { get; set; }

		/// <summary>A collection indicating which seasons and episodes in the show have been completed</summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeasonProgress> Seasons { get; set; }

		/// <summary>The next episode that needs to be completed in the context of a collection or watched history</summary>
		[JsonProperty(PropertyName = "next_episode")]
		public TraktEpisode NextEpisode { get; set; }

	}

}