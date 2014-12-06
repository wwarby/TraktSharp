using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A Trakt search results entry</summary>
	[Serializable]
	public class TraktSearchResult {

		/// <summary>The type of media item</summary>
		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }

		/// <summary>The relevance score for the entry</summary>
		[JsonProperty(PropertyName = "score")]
		public decimal? Score { get; set; }

		/// <summary>The movie (only populated if <see cref="Type"/> is <c>movie</c>)</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

		/// <summary>The show (only populated if <see cref="Type"/> is <c>show</c>)</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>The episode (only populated if <see cref="Type"/> is <c>episode</c>)</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		/// <summary>The person (only populated if <see cref="Type"/> is <c>person</c>)</summary>
		[JsonProperty(PropertyName = "person")]
		public TraktPerson Person { get; set; }

		/// <summary>The list (only populated if <see cref="Type"/> is <c>list</c>)</summary>
		[JsonProperty(PropertyName = "list")]
		public TraktList List { get; set; }

	}

}