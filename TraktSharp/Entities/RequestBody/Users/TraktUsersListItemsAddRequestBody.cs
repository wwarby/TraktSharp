using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Users {

	[Serializable]
	public class TraktUsersListItemsAddRequestBody {

		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovie> Movies { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShow> Shows { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeason> Seasons { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

		[JsonProperty(PropertyName = "people")]
		public IEnumerable<TraktPerson> People { get; set; }

		internal bool IsPostable() {
			return (Movies != null && Movies.Any())
				|| (Shows != null && Shows.Any()) 
				|| (Seasons != null && Seasons.Any()) 
				|| (Episodes != null && Episodes.Any())
				|| (People != null && People.Any());
		}

	}

}