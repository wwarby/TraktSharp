﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	[Serializable]
	public class TraktCrewMovieCredit {

		public TraktCrewMovieCredit() { Movie = new TraktMovie(); }

		[JsonProperty(PropertyName = "job")]
		public string Job { get; set; }

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}