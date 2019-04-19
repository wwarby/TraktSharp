using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A summary of user ratings for an item</summary>
	[Serializable]
	public class TraktRatings {

		/// <summary>The average rating</summary>
		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		/// <summary>The number of votes cast to arrive at the average rating</summary>
		[JsonProperty(PropertyName = "votes")]
		public int Votes { get; set; }

		/// <summary>The distribution of votes</summary>
		[JsonProperty(PropertyName = "distribution")]
		public Dictionary<string, int> Distribution { get; set; }

	}

}