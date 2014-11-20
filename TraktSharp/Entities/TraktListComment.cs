using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktListComment : TraktComment {

		[JsonProperty(PropertyName = "list")]
		public TraktList List { get; set; }

	}

}