using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowCredits {

		public TraktShowCredits() {
			Cast = new List<TraktCastShowCredit>();
			Crew = new TraktCrewShowCredits();
		}

		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastShowCredit> Cast { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public TraktCrewShowCredits Crew { get; set; }

	}

}