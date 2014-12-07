using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Entities.Response.Calendars {

	/// <summary>A structure representing the return data or part of the return data from one or more Trakt API methods</summary>
	[Serializable]
	public class TraktCalendarsShowsResponseItem {

		/// <summary>The day and time when the show airs</summary>
		[JsonProperty(PropertyName = "airs_at")]
		public DateTime AirsAt { get; set; }

		/// <summary>The episode</summary>
		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		/// <summary>The show</summary>
		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}