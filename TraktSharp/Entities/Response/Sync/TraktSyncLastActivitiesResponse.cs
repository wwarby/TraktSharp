using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncLastActivitiesResponse {

		[JsonProperty(PropertyName = "all")]
		public DateTime? All { get; set; }

		[JsonProperty(PropertyName = "movies")]
		public TraktSyncLastActivitiesResponseMovies Movies { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public TraktSyncLastActivitiesResponseEpisodes Episodes { get; set; }

		[JsonProperty(PropertyName = "shows")]
		public TraktSyncLastActivitiesResponseShows Shows { get; set; }

		[JsonProperty(PropertyName = "seasons")]
		public TraktSyncLastActivitiesResponseSeasons Seasons { get; set; }

		[JsonProperty(PropertyName = "comments")]
		public TraktSyncLastActivitiesResponseComments Comments { get; set; }

		[JsonProperty(PropertyName = "lists")]
		public TraktSyncLastActivitiesResponseLists Lists { get; set; }

	}

}