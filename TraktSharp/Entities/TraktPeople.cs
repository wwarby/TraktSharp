using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPeople {

		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastMember> Cast { get; set; }

		[JsonProperty(PropertyName = "crew")]
		public TraktCrew Crew { get; set; }

	}

}