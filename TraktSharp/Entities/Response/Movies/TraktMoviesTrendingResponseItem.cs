using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesTrendingResponseItem {

		/// <summary>The number of users watching this item</summary>
		[JsonProperty(PropertyName = "watchers")]
		public int? Watchers { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}