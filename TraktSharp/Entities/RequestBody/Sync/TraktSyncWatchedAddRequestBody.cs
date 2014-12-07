using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	/// <summary>Request body parameters for an add to history request</summary>
	[Serializable]
	public class TraktSyncWatchedAddRequestBody {

		/// <summary>A collection of movies with metadata related to a user's watched status in regard to those movies</summary>
		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithWatchedMetadata> Movies { get; set; }

		/// <summary>A collection of shows with metadata related to a user's watched status in regard to those shows</summary>
		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithWatchedMetadata> Shows { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's watched status in regard to those episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithWatchedMetadata> Episodes { get; set; }

		internal bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}