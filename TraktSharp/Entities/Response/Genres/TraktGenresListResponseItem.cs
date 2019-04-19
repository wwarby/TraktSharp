using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Genres {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktGenresListResponseItem {

		/// <summary>The genre display name</summary>
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		/// <summary>The Trakt slug for this genre. This is a SEO-friendly URL-safe unique representation of the item in words.</summary>
		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

	}

}