using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A season with metadata related to a user's collection of owned media</summary>
	[Serializable]
	public class TraktSeasonWithCollectionMetadata : TraktSeason {

		/// <summary>The UTC date when the item was collected</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

		/// <summary>The item's media type</summary>
		[JsonProperty(PropertyName = "media_type")]
		public MediaType MediaType { get; set; }

		/// <summary>The item's resolution</summary>
		[JsonProperty(PropertyName = "resolution")]
		public Resolution Resolution { get; set; }

		/// <summary>The item's audio format</summary>
		[JsonProperty(PropertyName = "audio")]
		public AudioFormat AudioFormat { get; set; }

		/// <summary>The number of channels in the item's audio track</summary>
		[JsonProperty(PropertyName = "audio_channels")]
		public AudioChannels AudioChannels { get; set; }

		/// <summary>Indicates if the item is in the 3D format</summary>
		[JsonProperty(PropertyName = "3d")]
		public bool? Is3D { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's collection of owned media in regard to each episode</summary>
		[JsonProperty(PropertyName = "episodes")]
		public new IEnumerable<TraktEpisodeWithCollectionMetadata> Episodes { get; set; }

	}

}