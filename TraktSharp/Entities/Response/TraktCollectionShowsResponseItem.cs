using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCollectionShowsResponseItem {

		/// <summary>The UTC date when the item was last collected</summary>
		[JsonProperty(PropertyName = "last_collected_at")]
		public DateTime? LastCollectedAt { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

		/// <summary>A collection of seasons</summary>
		[JsonProperty(PropertyName = "seasons")]
		public IEnumerable<TraktCollectionShowsResponseItemSeason> Seasons { get; set; }

	}

}