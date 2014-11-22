﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieImages {

		public TraktMovieImages() {
			Banner = new TraktImage();
			ClearArt = new TraktImage();
			FanArt = new TraktImageSet();
			Logo = new TraktImage();
			Poster = new TraktImageSet();
			Thumb = new TraktImage();
		}

		[JsonProperty(PropertyName = "banner")]
		public TraktImage Banner { get; set; }

		[JsonProperty(PropertyName = "clearart")]
		public TraktImage ClearArt { get; set; }

		[JsonProperty(PropertyName = "fanart")]
		public TraktImageSet FanArt { get; set; }

		[JsonProperty(PropertyName = "logo")]
		public TraktImage Logo { get; set; }

		[JsonProperty(PropertyName = "poster")]
		public TraktImageSet Poster { get; set; }

		[JsonProperty(PropertyName = "thumb")]
		public TraktImage Thumb { get; set; }

	}

}