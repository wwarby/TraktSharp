using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktEpisodeImages {

		public TraktEpisodeImages() {
			Screenshot = new TraktImageSet();
		}

		[JsonProperty(PropertyName = "screenshot")]
		public TraktImageSet Screenshot { get; set; }

	}

}