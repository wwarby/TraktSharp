using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktCrewMovieCredits {

		public TraktCrewMovieCredits() {
			Production = new List<TraktCrewMovieCredit>();
			Art = new List<TraktCrewMovieCredit>();
			Crew = new List<TraktCrewMovieCredit>();
			CostumeAndMakeUp = new List<TraktCrewMovieCredit>();
			Directing = new List<TraktCrewMovieCredit>();
			Writing = new List<TraktCrewMovieCredit>();
			Sound = new List<TraktCrewMovieCredit>();
			Camera = new List<TraktCrewMovieCredit>();
		}

		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewMovieCredit> Production { get; set; }

		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewMovieCredit> Art { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewMovieCredit> Crew { get; set; }

		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewMovieCredit> CostumeAndMakeUp { get; set; }

		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewMovieCredit> Directing { get; set; }

		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewMovieCredit> Writing { get; set; }

		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewMovieCredit> Sound { get; set; }

		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewMovieCredit> Camera { get; set; }

	}

}