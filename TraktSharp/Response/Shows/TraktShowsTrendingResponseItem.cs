using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response.Shows {

	[Serializable]
	public class TraktShowsUpdatesResponseItem {

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}