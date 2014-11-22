using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPersonImages {

		[JsonProperty(PropertyName = "headshot")]
		public TraktImageSet Headshot { get; set; }

	}

}