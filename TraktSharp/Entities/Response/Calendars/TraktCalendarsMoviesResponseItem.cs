using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Calendars {

	[Serializable]
	public class TraktCalendarsMoviesResponseItem {

		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}