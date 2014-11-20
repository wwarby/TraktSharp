using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktMovieComment : TraktComment {

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}