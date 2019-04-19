using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	/// <summary>Request body parameters for an add ratings request</summary>
	[Serializable]
	public class TraktSyncRatingsAddRequestBody {

		/// <summary>A collection of movies with metadata related to a user's rating of those movies</summary>
		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovieWithRatingsMetadata> Movies { get; set; }

		/// <summary>A collection of shows with metadata related to a user's rating of those shows</summary>
		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShowWithRatingsMetadata> Shows { get; set; }

		/// <summary>A collection of episodes with metadata related to a user's rating of those episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisodeWithRatingsMetadata> Episodes { get; set; }

		internal bool IsPostable() => (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());

	}

}