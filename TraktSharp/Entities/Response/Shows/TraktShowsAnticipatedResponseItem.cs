using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Shows {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktShowsAnticipatedResponseItem {

		/// <summary>The number of lists on which this item appears</summary>
		[JsonProperty(PropertyName = "list_count")]
		public int? ListCount { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}