using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Movies {

	[Serializable]
	public class TraktMoviesUpdatesResponseItem {

		[JsonProperty(PropertyName = "updated_at")]
		public DateTime UpdatedAt { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}