using System;
using Newtonsoft.Json;
using TraktSharp.Enums;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktRatingsShowsResponseItem {

		/// <summary>The user's rating of the item</summary>
		[JsonProperty(PropertyName = "rating")]
		public TraktRating Rating { get; set; }

		/// <summary>The UTC date when the item was rated</summary>
		[JsonProperty(PropertyName = "rated_at")]
		public DateTime? RatedAt { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}