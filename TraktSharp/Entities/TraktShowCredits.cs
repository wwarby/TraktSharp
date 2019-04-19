using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>Cast and crew credits show credits for a person</summary>
	[Serializable]
	public class TraktShowCredits {

		/// <summary>The cast</summary>
		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastShowCredit> Cast { get; set; }

		/// <summary>The crew</summary>
		[JsonProperty(PropertyName = "crew")]
		public TraktCrewShowCredits Crew { get; set; }

	}

}