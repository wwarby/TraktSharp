using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	[Serializable]
	public class TraktMovie {

		public TraktMovie() {
			Ids = new TraktMovieIds();
			AvailableTranslations = new List<string>();
			Genres = new List<string>();
		}

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktMovieIds Ids { get; set; }

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

	}

}