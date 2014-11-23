using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktUserImages {

		[JsonProperty(PropertyName = "avatar")]
		public TraktImage Avatar { get; set; }

	}

}