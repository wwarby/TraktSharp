using System;
using System.Globalization;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktMoviesAliasesResponseItem {

		/// <summary>The alias title</summary>
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		/// <summary>The country in which this alias is applicable in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "country")]
		public string CountryCode { get; set; }

		/// <summary>The country in which this alias is applicable</summary>
		[JsonIgnore]
		public string Country {
			get { try { return new RegionInfo(CountryCode).DisplayName; } catch { return string.Empty; } }
		}

	}

}