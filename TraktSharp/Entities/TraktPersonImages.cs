using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktPersonImages {

		public TraktPersonImages() { Headshot = new TraktImageSet(); }

		[JsonProperty(PropertyName = "headshot")]
		public TraktImageSet Headshot { get; set; }

	}

}