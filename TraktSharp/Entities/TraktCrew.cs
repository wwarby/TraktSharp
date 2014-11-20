using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktCrew {

		public TraktCrew() {
			Production = new List<TraktCrewMember>();
			Art = new List<TraktCrewMember>();
			Crew = new List<TraktCrewMember>();
			CostumeAndMakeUp = new List<TraktCrewMember>();
			Directing = new List<TraktCrewMember>();
			Writing = new List<TraktCrewMember>();
			Sound = new List<TraktCrewMember>();
			Camera = new List<TraktCrewMember>();
		}

		[JsonProperty(PropertyName = "production")]
		public IEnumerable<TraktCrewMember> Production { get; set; }

		[JsonProperty(PropertyName = "art")]
		public IEnumerable<TraktCrewMember> Art { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public IEnumerable<TraktCrewMember> Crew { get; set; }

		[JsonProperty(PropertyName = "costume & make-up")]
		public IEnumerable<TraktCrewMember> CostumeAndMakeUp { get; set; }

		[JsonProperty(PropertyName = "directing")]
		public IEnumerable<TraktCrewMember> Directing { get; set; }

		[JsonProperty(PropertyName = "writing")]
		public IEnumerable<TraktCrewMember> Writing { get; set; }

		[JsonProperty(PropertyName = "sound")]
		public IEnumerable<TraktCrewMember> Sound { get; set; }

		[JsonProperty(PropertyName = "camera")]
		public IEnumerable<TraktCrewMember> Camera { get; set; }

	}

}