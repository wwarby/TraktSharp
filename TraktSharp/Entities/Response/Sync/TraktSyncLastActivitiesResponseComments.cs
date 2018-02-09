using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktSyncLastActivitiesResponseComments {

		/// <summary>The UTC date when the user most recently "liked" a comment</summary>
		[JsonProperty(PropertyName = "liked_at")]
		public DateTimeOffset? LikedAt { get; set; }

	}

}