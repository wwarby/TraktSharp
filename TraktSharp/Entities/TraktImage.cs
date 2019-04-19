using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraktSharp.Entities {
	/// <summary>An image available in only one size</summary>
	public class TraktImage {
		[JsonIgnore]
		public int Id { get; set; }

		/// <summary>The URI to the full size image</summary>
		[JsonIgnore]
		[NotMapped]
		public Uri Full {
			get => !string.IsNullOrEmpty(FullString) ? new Uri(FullString) : null;
			set => FullString = value.AbsoluteUri;
		}

		[JsonProperty(PropertyName = "full")]
		private string FullString { get; set; }
	}
}