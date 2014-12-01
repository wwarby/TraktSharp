﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	[Serializable]
	public class TraktSyncRatingsAddRequestBody {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithRatingsMetadata> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithRatingsMetadata> Shows { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithRatingsMetadata> Episodes { get; set; }

		internal bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}