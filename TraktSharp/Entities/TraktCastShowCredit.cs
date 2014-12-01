using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A show credit for an actor or actress</summary>
	[Serializable]
	public class TraktCastShowCredit {

		/// <summary>The character name</summary>
		[JsonProperty(PropertyName = "character")]
		public string Character { get; set; }

		/// <summary>The show in which the character was portrayed</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}