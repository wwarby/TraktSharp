using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Entities {

	public class TraktLikeItem {

		[JsonProperty(PropertyName = "type")]
		private string _type;

		[JsonProperty(PropertyName = "liked_at")]
		public DateTimeOffset? LikedAt { get; set; }

		[JsonIgnore] [NotMapped] public TraktLikeType Type { get => TraktEnumHelper.FromDescription(_type, TraktLikeType.Unspecified); set => _type = TraktEnumHelper.GetDescription(value); }

		[JsonProperty(PropertyName = "comment")]
		public TraktComment Comment { get; set; }

		[JsonProperty(PropertyName = "list")] public TraktList List { get; set; }

	}

}