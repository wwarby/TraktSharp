using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktEpisodeComment : TraktComment {

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}