using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktListIds {

		[JsonProperty(PropertyName = "trakt")]
		public int? Trakt { get; set; }

		[JsonProperty(PropertyName = "slug")]
		public string Slug { get; set; }

		public bool HasAnyValuesSet() {
			return Trakt > 0 || !string.IsNullOrEmpty(Slug);
		}

		public string GetBestId() {
			if (Trakt.GetValueOrDefault() > 0) { return Trakt.GetValueOrDefault().ToString(CultureInfo.InvariantCulture); }
			if (!string.IsNullOrEmpty(Slug)) { return Slug; }
			return string.Empty;
		}

	}

}