using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A show</summary>
	[Serializable]
	public class TraktShow {

		/// <summary></summary>
		[JsonProperty(PropertyName = "airs")]
		public TraktShowAirs Airs { get; set; }

		/// <summary>A list of translation languages available for the show in the form of two-letter language codes</summary>
		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

		/// <summary>A list of translation languages available for the show</summary>
		[JsonIgnore]
		public List<string> AvailableTranslationLanguages {
			get {
				var ret = new List<string>();
				foreach (var code in AvailableTranslationLanguageCodes) {
					try {
						ret.Add(new RegionInfo(code).DisplayName);
					} catch {}
				}
				return ret;
			}
		}

		/// <summary>The show's certification</summary>
		[JsonProperty(PropertyName = "certification")]
		public string Certification { get; set; }

		/// <summary>The country in which the show is produced in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "country")]
		public string CountryCode { get; set; }

		/// <summary>The country in which the show is produced</summary>
		[JsonIgnore]
		public string Country {
			get { try { return new RegionInfo(CountryCode).DisplayName; } catch { return string.Empty; } }
		}

		/// <summary>The UTC date when the first episode of the first season was first aired</summary>
		[JsonProperty(PropertyName = "first_aired")]
		public DateTime? FirstAired { get; set; }

		/// <summary>The genres to the show is tagged with</summary>
		[JsonProperty(PropertyName = "genres")]
		public IEnumerable<string> Genres { get; set; }

		/// <summary>The URI of a trailer for the show</summary>
		[JsonIgnore]
		public Uri Trailer {
			get { return string.IsNullOrEmpty(TrailerString) ? new Uri(TrailerString) : null; }
			set { TrailerString = value.AbsoluteUri; }
		}

		[JsonProperty(PropertyName = "trailer")]
		private string TrailerString { get; set; }

		/// <summary>The URI of the show's homepage</summary>
		[JsonIgnore]
		public Uri Homepage {
			get { return string.IsNullOrEmpty(HomepageString) ? new Uri(HomepageString) : null; }
			set { HomepageString = value.AbsoluteUri; }
		}

		[JsonProperty(PropertyName = "homepage")]
		private string HomepageString { get; set; }

		/// <summary>A collection of unique identifiers for the show in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktShowIds Ids { get; set; }

		/// <summary>A collection of images related to the show</summary>
		[JsonProperty(PropertyName = "images")]
		public TraktShowImages Images { get; set; }

		/// <summary>The language of the show in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "language")]
		public string LanguageCode { get; set; }

		/// <summary>>The language of the show</summary>
		[JsonIgnore]
		public string Language {
			get { try { return new CultureInfo(CountryCode).DisplayName; } catch { return string.Empty; } }
		}

		/// <summary>The network that produces the show</summary>
		[JsonProperty(PropertyName = "network")]
		public string Network { get; set; }

		/// <summary>A synopsis of the show</summary>
		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		/// <summary>The average user rating for the show</summary>
		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		/// <summary>The running time for the show's episodes (in minutes)</summary>
		[JsonProperty(PropertyName = "runtime")]
		public int? Runtime { get; set; }

		/// <summary>The show's current status</summary>
		[JsonProperty(PropertyName = "status")]
		public string Status { get; set; }

		/// <summary>The show's title</summary>
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		/// <summary>The UTC date when the show was last updated</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		/// <summary>The show's release year (first episode of the first season)</summary>
		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		/// <summary></summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeason> Seasons { get; set; }

		/// <summary>Indicates if the instance contains the data required for it to be sent as part of a request body in a <c>POST</c> HTTP method</summary>
		/// <returns><c>true</c> if the instance is in a fit state to be <c>POSTed</c>, otherwise <c>false</c></returns>
		internal bool IsPostable() {
			return !string.IsNullOrEmpty(Title) || (Ids != null && Ids.HasAnyValuesSet());
		}

	}

}