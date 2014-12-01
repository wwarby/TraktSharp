using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A collection of unique identifiers for a list in various web services</summary>
	[Serializable]
	public class TraktListIds {

		/// <summary>The Trakt numeric ID for this item. If available, this is the best ID to use when calling API methods that take an ID as a parameter.</summary>
		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		/// <summary>The Trakt slug for this item. This is a SEO-friendly URL-safe unique representation of the item in words,=.</summary>
		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

		/// <summary>Tests if at least one of the IDs for this item has been set</summary>
		/// <returns><c>true</c> if one or more of the IDs for this item has a non-default value, otherwise <c>false</c></returns>
		public bool HasAnyValuesSet() {
			return Trakt > 0 || !string.IsNullOrEmpty(Slug);
		}

		/// <summary>Get the most reliable ID from those that have been set for this item, for use in methods where any ID type can be passed</summary>
		/// <returns>The ID as a string</returns>
		public string GetBestId() {
			if (Trakt.GetValueOrDefault() > 0) { return Trakt.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (!string.IsNullOrEmpty(Slug)) { return Slug; }
			return string.Empty;
		}

	}

}