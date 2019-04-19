using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>An episode of a show</summary>
	[Serializable]
	public class TraktEpisode {

		/// <summary>A list of translation languages available for the episode in the form of two-letter language codes</summary>
		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

		/// <summary>A list of translation languages available for the episode</summary>
		[JsonIgnore]
		public List<string> AvailableTranslationLanguages {
			get {
				var ret = new List<string>();
				foreach (var code in AvailableTranslationLanguageCodes) {
					try {
						ret.Add(new RegionInfo(code).DisplayName);
					} catch { }
				}

				return ret;
			}
		}

		/// <summary>The UTC date when the episode was first aired</summary>
		[JsonProperty(PropertyName = "first_aired")]
		public DateTimeOffset? FirstAired { get; set; }

		/// <summary>A collection of unique identifiers for the episode in various web services</summary>
		[JsonProperty(PropertyName = "ids")]
		public TraktEpisodeIds Ids { get; set; }

		/// <summary>The episode number within the season to which it belongs</summary>
		[JsonProperty(PropertyName = "number")]
		public int? EpisodeNumber { get; set; }

		/// <summary>The episode number, numbered absolutely from the first episode in the first season</summary>
		[JsonProperty(PropertyName = "number_abs")]
		public int? EpisodeNumberAbsolute { get; set; }

		/// <summary>A synopsis of the episode</summary>
		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		/// <summary>The average user rating for the episode</summary>
		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		/// <summary>The season number in which the episode was aired</summary>
		[JsonProperty(PropertyName = "season")]
		public int? SeasonNumber { get; set; }

		/// <summary>The episode title</summary>
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		/// <summary>The UTC date when the episode was last updated</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTimeOffset? UpdatedAt { get; set; }

		/// <summary>
		///     Indicates if the instance contains the data required for it to be sent as part of a request body in a
		///     <c>POST</c> HTTP method
		/// </summary>
		/// <param name="show">A <see cref="TraktShow" /> instance that would be <c>POSTed</c> alongside the episode</param>
		/// <returns><c>true</c> if the instance is in a fit state to be <c>POSTed</c>, otherwise <c>false</c></returns>
		internal bool IsPostable(TraktShow show = null) => ((Ids != null) && Ids.HasAnyValuesSet()) || ((show != null) && !string.IsNullOrEmpty(show.Title) && (SeasonNumber > 0) && (EpisodeNumber > 0));

	}

}