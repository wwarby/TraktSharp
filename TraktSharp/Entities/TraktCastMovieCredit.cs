using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A movie credit for an actor or actress</summary>
	[Serializable]
	public class TraktCastMovieCredit {

		/// <summary>The character name</summary>
		[JsonProperty(PropertyName = "character")]
		public string Character { get; set; }

		/// <summary>The movie in which the character was portrayed</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}