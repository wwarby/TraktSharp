using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A member of the cast for a movie or show</summary>
	[Serializable]
	public class TraktCastMember {

		/// <summary>The character name</summary>
		[JsonProperty(PropertyName = "character")]
		public string Character { get; set; }

		/// <summary>The actor or actress</summary>
		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

	}

}