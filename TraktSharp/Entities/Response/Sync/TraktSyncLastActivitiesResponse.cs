using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponse {

		/// <summary>The UTC date when the user most recently had any interaction with the Trakt service</summary>
		[JsonProperty(PropertyName = "all")]
		public DateTimeOffset? All { get; set; }

		/// <summary>The dates when the user most recently had any interaction with movies on the Trakt service</summary>
		[JsonProperty(PropertyName = "movies")]
		public TraktSyncLastActivitiesResponseMovies Movies { get; set; }

		/// <summary>The dates when the user most recently had any interaction with episodes on the Trakt service</summary>
		[JsonProperty(PropertyName = "episodes")]
		public TraktSyncLastActivitiesResponseEpisodes Episodes { get; set; }

		/// <summary>The dates when the user most recently had any interaction with shows on the Trakt service</summary>
		[JsonProperty(PropertyName = "shows")]
		public TraktSyncLastActivitiesResponseShows Shows { get; set; }

		/// <summary>The dates when the user most recently had any interaction with seasons on the Trakt service</summary>
		[JsonProperty(PropertyName = "seasons")]
		public TraktSyncLastActivitiesResponseSeasons Seasons { get; set; }

		/// <summary>The dates when the user most recently had any interaction with comments on the Trakt service</summary>
		[JsonProperty(PropertyName = "comments")]
		public TraktSyncLastActivitiesResponseComments Comments { get; set; }

		/// <summary>The dates when the user most recently had any interaction with lists on the Trakt service</summary>
		[JsonProperty(PropertyName = "lists")]
		public TraktSyncLastActivitiesResponseLists Lists { get; set; }

	}

}