using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesUpdatesResponseItem {

		/// <summary>The UTC date when this movie was updated</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTimeOffset UpdatedAt { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}