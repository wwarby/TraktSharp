using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Crew members for a movie or show grouped into categories by department</summary>
	[Serializable]
	public class TraktCrew {

		/// <summary>Crew members from the production department</summary>
		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewMember> Production { get; set; }

		/// <summary>Crew members from the art department</summary>
		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewMember> Art { get; set; }

		/// <summary>Crew members from the crew department</summary>
		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewMember> Crew { get; set; }

		/// <summary>Crew members from the costume &amp; make-up department</summary>
		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewMember> CostumeAndMakeUp { get; set; }

		/// <summary>Crew members from the directing department</summary>
		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewMember> Directing { get; set; }

		/// <summary>Crew members from the writing department</summary>
		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewMember> Writing { get; set; }

		/// <summary>Crew members from the sound department</summary>
		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewMember> Sound { get; set; }

		/// <summary>Crew members from the camera department</summary>
		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewMember> Camera { get; set; }

	}

}