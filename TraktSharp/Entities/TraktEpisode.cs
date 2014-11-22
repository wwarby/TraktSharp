using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktEpisode {

		public TraktEpisode() {
			AvailableTranslations = new List<string>();
			Ids = new TraktEpisodeIds();
			Images = new TraktEpisodeImages();
		}

		[JsonProperty(PropertyName = "available_translations")]
		public IEnumerable<string> AvailableTranslations { get; set; }

		[JsonProperty(PropertyName = "first_aired")]
		public DateTime? FirstAired { get; set; }

		[JsonProperty(PropertyName = "ids")]
		public TraktEpisodeIds Ids { get; set; }

		[JsonProperty(PropertyName = "images")]
		public TraktEpisodeImages Images { get; set; }

		[JsonProperty(PropertyName = "number")]
		public int? Number { get; set; }

		[JsonProperty(PropertyName = "number_abs")]
		public int? NumberAbsolute { get; set; }

		[JsonProperty(PropertyName = "overview")]
		public string Overview { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal? Rating { get; set; }

		[JsonProperty(PropertyName = "season")]
		public int? Season { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

		public bool IsPostable(TraktShow show = null) {
			return (Ids != null && Ids.HasAnyValuesSet()) || (show != null && !string.IsNullOrEmpty(show.Title) && Season.HasValue && Number.HasValue);
		}

	}

}