using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of images related to a person</summary>
	[Serializable]
	public class TraktPersonImages {

		/// <summary>A headshot image</summary>
		[JsonProperty(PropertyName = "headshot")]
		public TraktImageSet Headshot { get; set; }

	}

}