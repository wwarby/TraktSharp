using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktEpisodeImages {

		[JsonProperty(PropertyName = "screenshot")]
		public TraktImageSet Screenshot { get; set; }

	}

}