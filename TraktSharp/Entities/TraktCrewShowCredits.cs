using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Credits for a crew member on a show grouped into categories by department</summary>
	[Serializable]
	public class TraktCrewShowCredits {

		/// <summary>Credits for a crew member in which their role was in the production department</summary>
		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewShowCredit> Production { get; set; }

		/// <summary>Credits for a crew member in which their role was in the art department</summary>
		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewShowCredit> Art { get; set; }

		/// <summary>Credits for a crew member in which their role was in the crew department</summary>
		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewShowCredit> Crew { get; set; }

		/// <summary>Credits for a crew member in which their role was in the costume & make-up department</summary>
		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewShowCredit> CostumeAndMakeUp { get; set; }

		/// <summary>Credits for a crew member in which their role was in the directing department</summary>
		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewShowCredit> Directing { get; set; }

		/// <summary>Credits for a crew member in which their role was in the writing department</summary>
		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewShowCredit> Writing { get; set; }

		/// <summary>Credits for a crew member in which their role was in the sound department</summary>
		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewShowCredit> Sound { get; set; }

		/// <summary>Credits for a crew member in which their role was in the camera department</summary>
		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewShowCredit> Camera { get; set; }

	}

}