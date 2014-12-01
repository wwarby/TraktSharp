using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of images related to a show</summary>
	[Serializable]
	public class TraktShowImages {

		/// <summary>A banner image</summary>
		[JsonProperty(PropertyName = "banner")]
		public TraktImage Banner { get; set; }

		/// <summary>A clearart image</summary>
		[JsonProperty(PropertyName = "clearart")]
		public TraktImage ClearArt { get; set; }

		/// <summary>A fan art image</summary>
		[JsonProperty(PropertyName = "fanart")]
		public TraktImageSet FanArt { get; set; }

		/// <summary>A logo image</summary>
		[JsonProperty(PropertyName = "logo")]
		public TraktImage Logo { get; set; }

		/// <summary>A poster image</summary>
		[JsonProperty(PropertyName = "poster")]
		public TraktImageSet Poster { get; set; }

		/// <summary>A thumbnail image</summary>
		[JsonProperty(PropertyName = "thumb")]
		public TraktImage Thumb { get; set; }

	}

}