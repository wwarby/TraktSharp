using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of images related to a season</summary>
	[Serializable]
	public class TraktSeasonImages {

		/// <summary>A poster image</summary>
		[JsonProperty(PropertyName = "poster")]
		public TraktImageSet Poster { get; set; }

		/// <summary>A thumbnail image</summary>
		[JsonProperty(PropertyName = "thumb")]
		public TraktImage Thumb { get; set; }

	}

}