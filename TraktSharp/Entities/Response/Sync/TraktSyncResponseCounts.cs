using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Sync {

	[Serializable]
	public class TraktSyncResponseCounts {

		[JsonProperty(PropertyName = "movies")]
		public int? Movies { get; set; }

		[JsonProperty(PropertyName = "episodes")]
		public int? Episodes { get; set; }

	}

}