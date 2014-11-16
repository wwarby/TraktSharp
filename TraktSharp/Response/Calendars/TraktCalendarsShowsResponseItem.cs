using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response.Calendars {

	[Serializable]
	public class TraktCalendarsShowsResponseItem {

		[JsonProperty(PropertyName = "airs_at")]
		public DateTime AirsAt { get; set; }

		[JsonProperty(PropertyName = "episode")]
		public TraktEpisode Episode { get; set; }

		[JsonProperty(PropertyName = "show")]
		public TraktShow Show { get; set; }

	}

}