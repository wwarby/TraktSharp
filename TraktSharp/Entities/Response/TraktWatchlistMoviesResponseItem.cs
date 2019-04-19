using System;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktWatchlistMoviesResponseItem {

		/// <summary>The UTC date when the item was added to the list</summary>
		[JsonProperty(PropertyName = "listed_at")]
		public DateTime? ListedAt { get; set; }

		/// <summary>The type of media item</summary>
		[JsonIgnore]
		public TraktListItemType Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string TypeString => TraktEnumHelper.GetDescription(Type);

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}