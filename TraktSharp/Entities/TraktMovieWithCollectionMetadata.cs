using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieWithCollectionMetadata : TraktMovie {

		[JsonProperty(PropertyName = "collected_at")]
		public DateTime? CollectedAt { get; set; }

		[JsonProperty(PropertyName = "media_type")]
		public MediaType MediaType { get; set; }

		[JsonProperty(PropertyName = "resolution")]
		public Resolution Resolution { get; set; }

		[JsonProperty(PropertyName = "audio")]
		public AudioFormat AudioFormat { get; set; }
		
		[JsonProperty(PropertyName = "audio_channels")]
		public AudioChannels AudioChannels { get; set; }

		[JsonProperty(PropertyName = "3d")]
		public bool? Is3d { get; set; }

	}

}