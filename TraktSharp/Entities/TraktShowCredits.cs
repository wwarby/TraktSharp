using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowCredits {

		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastShowCredit> Cast { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public TraktCrewShowCredits Crew { get; set; }

	}

}