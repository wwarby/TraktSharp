using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktCrewShowCredits {

		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewShowCredit> Production { get; set; }

		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewShowCredit> Art { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewShowCredit> Crew { get; set; }

		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewShowCredit> CostumeAndMakeUp { get; set; }

		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewShowCredit> Directing { get; set; }

		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewShowCredit> Writing { get; set; }

		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewShowCredit> Sound { get; set; }

		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewShowCredit> Camera { get; set; }

	}

}