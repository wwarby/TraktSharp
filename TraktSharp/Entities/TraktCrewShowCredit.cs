using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A movie credit for an crew member</summary>
	[Serializable]
	public class TraktCrewShowCredit {

		/// <summary>The crew member's job on the show</summary>
		[JsonProperty(PropertyName = "job")]
		public string Job { get; set; }

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}