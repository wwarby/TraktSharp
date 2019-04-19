using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An image available in multiple sizes</summary>
	[Serializable]
	public class TraktImageSet {

		/// <summary>The URI to the full size image</summary>
		[JsonIgnore]
		public Uri Full {
			get => !string.IsNullOrEmpty(FullString) ? new Uri(FullString) : null;
			set => FullString = value.AbsoluteUri;
		}

		[JsonProperty(PropertyName = "full")]
		private string FullString { get; set; }

		/// <summary>The URI to the medium size image</summary>
		[JsonIgnore]
		public Uri Medium {
			get => !string.IsNullOrEmpty(MediumString) ? new Uri(MediumString) : null;
			set => MediumString = value.AbsoluteUri;
		}

		[JsonProperty(PropertyName = "medium")]
		private string MediumString { get; set; }

		/// <summary>The URI to the thumbnail size image</summary>
		[JsonIgnore]
		public Uri Thumb {
			get => !string.IsNullOrEmpty(ThumbString) ? new Uri(ThumbString) : null;
			set => ThumbString = value.AbsoluteUri;
		}

		[JsonProperty(PropertyName = "thumb")]
		private string ThumbString { get; set; }

	}

}