using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {
	
	/// <summary>A member of the crew for a movie or show</summary>
	[Serializable]
	public class TraktCrewMember {

		/// <summary>The crew member's job</summary>
		[JsonProperty(PropertyName = "job")]
		public string Job { get; set; }

		/// <summary>The crew member</summary>
		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

	}

}