using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	[Serializable]
	public class TraktSyncCollectionAddRequestBody {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithCollectionMetadata> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithCollectionMetadata> Shows { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithCollectionMetadata> Episodes { get; set; }

		internal bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}