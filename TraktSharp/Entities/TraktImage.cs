using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An image available in only one size</summary>
	[Serializable]
	public class TraktImage {

		/// <summary>The URL to the full size image</summary>
		[JsonProperty(PropertyName = "full")]
		public string Full { get; set; }

	}

}