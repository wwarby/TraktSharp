using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Credits for a crew member on a movie grouped into categories by department</summary>
	[Serializable]
	public class TraktCrewMovieCredits {

		/// <summary>Credits for a crew member in which their role was in the production department</summary>
		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewMovieCredit> Production { get; set; }

		/// <summary>Credits for a crew member in which their role was in the art department</summary>
		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewMovieCredit> Art { get; set; }

		/// <summary>Credits for a crew member in which their role was in the crew department</summary>
		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewMovieCredit> Crew { get; set; }

		/// <summary>Credits for a crew member in which their role was in the costume &amp; make-up department</summary>
		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewMovieCredit> CostumeAndMakeUp { get; set; }

		/// <summary>Credits for a crew member in which their role was in the directing department</summary>
		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewMovieCredit> Directing { get; set; }

		/// <summary>Credits for a crew member in which their role was in the writing department</summary>
		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewMovieCredit> Writing { get; set; }

		/// <summary>Credits for a crew member in which their role was in the sound department</summary>
		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewMovieCredit> Sound { get; set; }

		/// <summary>Credits for a crew member in which their role was in the camera department</summary>
		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewMovieCredit> Camera { get; set; }

	}

}