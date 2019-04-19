using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	/// <summary>A show with metadata related to a user's collection of owned media</summary>
	[Serializable]
	public class TraktShowWithCollectionMetadata : TraktShow {

		/// <summary>The UTC date when the item was collected</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

		/// <summary>The item's media type</summary>
		[JsonIgnore]
		public TraktMediaType MediaType { get; set; }

		[JsonProperty(PropertyName = "media_type")]
		private string MediaTypeString => TraktEnumHelper.GetDescription(MediaType);

    /// <summary>The item's resolution</summary>
		[JsonIgnore]
		public TraktResolution Resolution { get; set; }

		[JsonProperty(PropertyName = "resolution")]
		private string ResolutionString => TraktEnumHelper.GetDescription(Resolution);

    /// <summary>The item's audio format</summary>
		[JsonIgnore]
		public TraktAudioFormat AudioFormat { get; set; }

		[JsonProperty(PropertyName = "audio")]
		private string AudioFormatString => TraktEnumHelper.GetDescription(AudioFormat);

    /// <summary>The number of channels in the item's audio track</summary>
		[JsonIgnore]
		public TraktAudioChannels AudioChannels { get; set; }

		[JsonProperty(PropertyName = "audio_channels")]
		private string AudioChannelsString => TraktEnumHelper.GetDescription(AudioChannels);

    /// <summary>Indicates if the item is in the 3D format</summary>
		[JsonProperty(PropertyName = "3d")]
		public bool? Is3D { get; set; }

		/// <summary>A collection of seasons with metadata related to a user's collection of owned media in regard to each season</summary>
		[JsonProperty(PropertyName = "seasons")]
		public new IEnumerable<TraktSeasonWithCollectionMetadata> Seasons { get; set; }

	}

}