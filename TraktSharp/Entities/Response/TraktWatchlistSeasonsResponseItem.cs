using System;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities.Response {

	[Serializable]
	public class TraktWatchlistSeasonsResponseItem {

		[JsonProperty(PropertyName = "listed_at")]
		public DateTime? RatedAt { get; set; }

		[JsonIgnore]
		public TraktListItemType Type { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string TypeString { get { return TraktEnumHelper.GetDescription(Type); } }

		[JsonProperty(PropertyName = "season")]
		public TraktSeason Season { get; set; }

	}

}