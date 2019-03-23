﻿using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	/// <summary>An episode with metadata related to a user's collection of owned media</summary>
	[Serializable]
	public class TraktEpisodeWithCollectionMetadata : TraktEpisode {

		/// <summary>The UTC date when the item was collected</summary>
		[JsonProperty(PropertyName = "collected_at")]
		public DateTimeOffset? CollectedAt { get; set; }

		/// <summary>The item's media type</summary>
		[JsonIgnore]
		public TraktMediaType MediaType { get; set; }

		[JsonProperty(PropertyName = "media_type")]
		private string MediaTypeString { get { return TraktEnumHelper.GetDescription(MediaType); } }

		/// <summary>The item's resolution</summary>
		[JsonIgnore]
		public TraktResolution Resolution { get; set; }

		[JsonProperty(PropertyName = "resolution")]
		private string ResolutionString { get { return TraktEnumHelper.GetDescription(Resolution); } }

		/// <summary>The item's audio format</summary>
		[JsonIgnore]
		public TraktAudioFormat AudioFormat { get; set; }

		[JsonProperty(PropertyName = "audio")]
		private string AudioFormatString { get { return TraktEnumHelper.GetDescription(AudioFormat); } }

		/// <summary>The number of channels in the item's audio track</summary>
		[JsonIgnore]
		public TraktAudioChannels AudioChannels { get; set; }

		[JsonProperty(PropertyName = "audio_channels")]
		private string AudioChannelsString { get { return TraktEnumHelper.GetDescription(AudioChannels); } }

		/// <summary>Indicates if the item is in the 3D format</summary>
		[JsonProperty(PropertyName = "3d")]
		public bool? Is3D { get; set; }

	}

}