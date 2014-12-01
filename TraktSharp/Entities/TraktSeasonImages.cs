using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktSeasonImages {

		[JsonProperty(PropertyName = "poster")]
		public TraktImageSet Poster { get; set; }

		[JsonProperty(PropertyName = "thumb")]
		public TraktImage Thumb { get; set; }

	}

}