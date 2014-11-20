using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktShowComment : TraktComment {

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}