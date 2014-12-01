using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An image available in multiple sizes</summary>
	[Serializable]
	public class TraktImageSet {

		/// <summary>The URL to the full size image</summary>
		[JsonProperty(PropertyName = "full")]
		public string Full { get; set; }

		/// <summary>The URL to the medium size image</summary>
		[JsonProperty(PropertyName = "medium")]
		public string Medium { get; set; }

		/// <summary>The URL to the thumbnail size image</summary>
		[JsonProperty(PropertyName = "thumb")]
		public string Thumb { get; set; }

	}

}