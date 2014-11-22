using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieCredits {

		public TraktMovieCredits() {
			Cast = new List<TraktCastMovieCredit>();
			Crew = new TraktCrewMovieCredits();
		}

		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastMovieCredit> Cast { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public TraktCrewMovieCredits Crew { get; set; }

	}

}