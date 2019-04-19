using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.RequestBody.Users {

	/// <summary>Request body parameters for an add to list request</summary>
	[Serializable]
	public class TraktUsersListItemsAddRequestBody {

		/// <summary>A collection of movies</summary>
		[JsonProperty(PropertyName = "movies")]
		public IEnumerable<TraktMovie> Movies { get; set; }

		/// <summary>A collection of shows</summary>
		[JsonProperty(PropertyName = "shows")]
		public IEnumerable<TraktShow> Shows { get; set; }

		/// <summary>A collection of seasons</summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktSeason> Seasons { get; set; }

		/// <summary>A collection of episodes</summary>
		[JsonProperty(PropertyName = "episodes")]
		public IEnumerable<TraktEpisode> Episodes { get; set; }

		/// <summary>A collection of people</summary>
		[JsonProperty(PropertyName = "people")]
		public IEnumerable<TraktPerson> People { get; set; }

		internal bool IsPostable() =>
			(Movies != null && Movies.Any())
			|| (Shows != null && Shows.Any())
			|| (Seasons != null && Seasons.Any())
			|| (Episodes != null && Episodes.Any())
			|| (People != null && People.Any());

	}

}