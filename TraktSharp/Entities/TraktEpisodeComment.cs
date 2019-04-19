using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A comment from a user related to an episode</summary>
	[Serializable]
	public class TraktEpisodeComment : TraktComment {

		/// <summary>The episode to which the comment relates</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

	}

}