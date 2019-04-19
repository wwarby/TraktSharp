using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>The cast and crew for a movie or show</summary>
	[Serializable]
	public class TraktCastAndCrew {

		/// <summary>The cast</summary>
		[JsonProperty(PropertyName = "cast")]
		public IEnumerable<TraktCastMember> Cast { get; set; }

		/// <summary>The crew</summary>
		[JsonProperty(PropertyName = "crew")]
		public TraktCrew Crew { get; set; }

	}

}