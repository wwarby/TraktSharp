using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Shows {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktShowsTranslationsResponseItem {

		/// <summary>The translated title</summary>
		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		/// <summary>The translated overview</summary>
		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		/// <summary>The language of this translation in the form of a two-letter language code</summary>
		[JsonProperty(PropertyName = "language")]
		public string LanguageCode { get; set; }

		/// <summary>The language of this translation</summary>
		[JsonIgnore]
		public string Language {
			get { try { return new CultureInfo(LanguageCode).DisplayName; } catch { return string.Empty; } }
		}

	}

}