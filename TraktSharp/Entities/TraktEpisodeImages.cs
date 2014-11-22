using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktEpisodeImages {

		public TraktEpisodeImages() { Screenshot = new TraktImageSet(); }

		[JsonProperty(PropertyName = "screenshot")]
		public TraktImageSet Screenshot { get; set; }

	}

}