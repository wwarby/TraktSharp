using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An image available in only one size</summary>
	[Serializable]
	public class TraktImage {

		/// <summary>The URI to the full size image</summary>
		[JsonIgnore]
		public Uri Full {
			get { return string.IsNullOrEmpty(FullString) ? new Uri(FullString) : null; }
			set { FullString = value.AbsoluteUri; }
		}

		[JsonProperty(PropertyName = "full")]
		private string FullString { get; set; }

	}

}