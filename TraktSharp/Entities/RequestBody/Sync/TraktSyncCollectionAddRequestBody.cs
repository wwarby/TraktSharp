using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	/// <summary>Request body parameters for an add to collection request</summary>
	[Serializable]
	public class TraktSyncCollectionAddRequestBody {

		/// <summary>A collection of movies with metadata related to a user's collection of owned media</summary>
		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithCollectionMetadata> Movies { get; set; }

		/// <summary>A collection of shows with metadata related to a user's collection of owned media</summary>
		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithCollectionMetadata> Shows { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's collection of owned media</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithCollectionMetadata> Episodes { get; set; }

		internal bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}