using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	[Serializable]
	public class TraktSyncWatchedAddRequestBody {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithWatchedMetadata> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithWatchedMetadata> Shows { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithWatchedMetadata> Episodes { get; set; }

		public bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}