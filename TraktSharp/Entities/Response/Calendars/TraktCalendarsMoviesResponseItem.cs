using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Calendars {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCalendarsMoviesResponseItem {

		/// <summary>The movie</summary>
		[JsonProperty(PropertyName = "movie")]
		public TraktMovie Movie { get; set; }

	}

}