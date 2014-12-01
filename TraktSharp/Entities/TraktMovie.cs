using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovie {

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktMovieIds Ids { get; set; }

		[JsonProperty(PropertyName = "images")]
		public TraktMovieImages Images { get; set; }

		[JsonProperty(PropertyName = "tagline")]
		public string Tagline { get; set; }

		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		[JsonProperty(PropertyName = "released")]
		public DateTime? Released { get; set; }

		[JsonProperty(PropertyName = "runtime")]
		public int? Runtime { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "trailer")]
		public string Trailer { get; set; }

		[JsonProperty(PropertyName = "homepage")]
		public string Homepage { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		[JsonProperty(PropertyName = "language")]
		public string Language { get; set; }

		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslations { get; set; }

		[JsonProperty(PropertyName = "genres")]
		public IEnumerable<string> Genres { get; set; }

		/// <summary>Indicates if the instance contains the data required for it to be sent as part of a request body in a <c>POST</c> HTTP method</summary>
		/// <returns><c>true</c> if the instance is in a fit state to be <c>POSTed</c>, otherwise <c>false</c></returns>
		internal bool IsPostable() {
			return (!string.IsNullOrEmpty(Title) && Year.HasValue) || (Ids != null && Ids.HasAnyValuesSet());
		}

	}

}