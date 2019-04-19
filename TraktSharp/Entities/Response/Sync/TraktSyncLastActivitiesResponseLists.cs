using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseLists {

		/// <summary>The UTC date when the user most recently "liked" a list</summary>
		[JsonProperty(PropertyName = "liked_at")]
		public DateTime? LikedAt { get; set; }

		/// <summary>The UTC date when the user most recently updated a list</summary>
		[JsonProperty(PropertyName = "updated_at")]
		public DateTime? UpdatedAt { get; set; }

	}

}