using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Describes whether a particular season is completed in the context of a collection or watched history</summary>
	[Serializable]
	public class TraktSeasonProgress {

		/// <summary>The season number</summary>
		[JsonProperty(PropertyName = "number")]
		public int? SeasonNumber { get; set; }

		/// <summary>The number of episodes in this season which have been aired to date</summary>
		[JsonProperty(PropertyName = "aired")]
		public int? AiredCount { get; set; }

		/// <summary>The number of aired episodes in this season which have been completed</summary>
		[JsonProperty(PropertyName = "completed")]
		public int? Completed { get; set; }

		/// <summary>A collection indicating which episodes in this season have been completed</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeProgress> Episodes { get; set; }

	}

}