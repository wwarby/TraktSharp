using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A movie</summary>
	[Serializable]
	public class TraktMovie {

		/// <summary>The movie title</summary>
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		/// <summary>The movie release year</summary>
		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		/// <summary>A collection of unique identifiers for the movie in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktMovieIds Ids { get; set; }

		/// <summary>The movie's promotional tag line</summary>
		[JsonProperty(PropertyName = "tagline")]
		public string Tagline { get; set; }

		/// <summary>A synopsis of the movie</summary>
		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		/// <summary>The UTC date when the movie was first released</summary>
		[JsonProperty(PropertyName = "released")]
		public DateTimeOffset? Released { get; set; }

		/// <summary>The movie's running time (in minutes)</summary>
		[JsonProperty(PropertyName = "runtime")]
		public int? Runtime { get; set; }

		/// <summary>The UTC date when the movie was last updated</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTimeOffset? UpdatedAt { get; set; }

		/// <summary>The URI of a trailer for the movie</summary>
		[JsonIgnore]
		public Uri Trailer {
			get => !string.IsNullOrEmpty(TrailerString) ? new Uri(TrailerString) : null;
      set => TrailerString = value.AbsoluteUri;
    }

		[JsonProperty(PropertyName = "trailer")]
		private string TrailerString { get; set; }

		/// <summary>The URI of the movie's homepage</summary>
		[JsonIgnore]
		public Uri Homepage {
			get => !string.IsNullOrEmpty(HomepageString) ? new Uri(HomepageString) : null;
      set => HomepageString = value.AbsoluteUri;
    }

		[JsonProperty(PropertyName = "homepage")]
		private string HomepageString { get; set; }

		/// <summary>The average user rating for the movie</summary>
		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		/// <summary>The language of the movie in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "language")]
		public string LanguageCode { get; set; }

		/// <summary>>The language of the movie</summary>
		[JsonIgnore]
		public string Language {
			get { try { return new CultureInfo(LanguageCode).DisplayName; } catch { return string.Empty; } }
		}

		/// <summary>A list of translation languages available for the movie in the form of two-letter language codes</summary>
		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

		/// <summary>A list of translation languages available for the movie</summary>
		[JsonIgnore]
		public List<string> AvailableTranslationLanguages {
			get {
				var ret = new List<string>();
				foreach (var code in AvailableTranslationLanguageCodes) {
					try {
						ret.Add(new RegionInfo(code).DisplayName);
					}
					catch { }
				}
				return ret;
			}
		}

		/// <summary>The genres to the movie is tagged with</summary>
		[JsonProperty(PropertyName = "genres")]
		public IEnumerable<string> Genres { get; set; }

		/// <summary>Indicates if the instance contains the data required for it to be sent as part of a request body in a <c>POST</c> HTTP method</summary>
		/// <returns><c>true</c> if the instance is in a fit state to be <c>POSTed</c>, otherwise <c>false</c></returns>
		internal bool IsPostable() => (!string.IsNullOrEmpty(Title) && Year.HasValue) || (Ids != null && Ids.HasAnyValuesSet());

	}

}