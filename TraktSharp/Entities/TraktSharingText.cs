using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A set of templates for the text to use when publishing social media updates</summary>
	[Serializable]
	public class TraktSharingText {

		/// <summary>The template for watching an item</summary>
		[JsonProperty(PropertyName = "watching")]
		public string Watching { get; set; }

		/// <summary>The template for an item just watched</summary>
		[JsonProperty(PropertyName = "watched")]
		public string Watched { get; set; }

	}

}