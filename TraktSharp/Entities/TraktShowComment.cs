using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A comment from a user related to a show</summary>
	[Serializable]
	public class TraktShowComment : TraktComment {

		/// <summary>The show to which the comment relates</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}