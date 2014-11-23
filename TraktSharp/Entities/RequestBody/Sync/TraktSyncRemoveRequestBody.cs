using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Sync {

	[Serializable]
	public class TraktSyncRemoveRequestBody {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovie> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShow> Shows { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

		public bool IsPostable() {
			return (Movies != null && Movies.Any()) || (Shows != null && Shows.Any()) || (Episodes != null && Episodes.Any());
		}

	}

}