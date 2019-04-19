using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesBoxOfficeResponseItem {

		/// <summary>The revenue made by this item at the box office</summary>
		[JsonProperty(PropertyName = "revenue")]
		public decimal? Revenue { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}