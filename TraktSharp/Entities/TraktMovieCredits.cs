using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Cast and crew credits movie credits for a person</summary>
	[Serializable]
	public class TraktMovieCredits {

		/// <summary>The cast</summary>
		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastMovieCredit> Cast { get; set; }

		/// <summary>The crew</summary>
		[JsonProperty(PropertyName = "crew")]
		public TraktCrewMovieCredits Crew { get; set; }

	}

}