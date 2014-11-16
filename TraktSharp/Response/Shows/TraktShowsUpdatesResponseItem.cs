using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response.Shows {

	[Serializable]
	public class TraktShowsTrendingResponseItem {

		[JsonProperty(PropertyName = "watchers")]
		public int Watchers { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}