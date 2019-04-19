using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A comment from a user related to a movie</summary>
	[Serializable]
	public class TraktMovieComment : TraktComment {

		/// <summary>The movie to which the comment relates</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}