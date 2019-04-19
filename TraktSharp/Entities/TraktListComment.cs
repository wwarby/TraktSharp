using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A comment from a user related to a list</summary>
	[Serializable]
	public class TraktListComment : TraktComment {

		/// <summary>The list to which the comment relates</summary>
		[JsonProperty(PropertyName = "list")]
		public TraktList List { get; set; }

	}

}