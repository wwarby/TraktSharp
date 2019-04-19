using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Shows {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktShowsTrendingResponseItem {

		/// <summary>The number of users currently watching this show</summary>
		[JsonProperty(PropertyName = "watchers")]
		public int Watchers { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}