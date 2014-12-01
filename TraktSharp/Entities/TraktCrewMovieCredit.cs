using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A movie credit for an crew member</summary>
	[Serializable]
	public class TraktCrewMovieCredit {

		/// <summary>The crew member's job on this movie</summary>
		[JsonProperty(PropertyName = "job")]
		public string Job { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}