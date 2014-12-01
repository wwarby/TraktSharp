using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of images related to an episode</summary>
	[Serializable]
	public class TraktEpisodeImages {

		/// <summary>A screenshot image</summary>
		[JsonProperty(PropertyName = "screenshot")]
		public TraktImageSet Screenshot { get; set; }

	}

}