using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TraktSharp.Enums;

namespace TraktSharp.Entities {
	public class TraktLikeItem {
		[JsonProperty(PropertyName = "liked_at")]
		public DateTimeOffset? LikedAt { get; set; }

		[JsonProperty(PropertyName = "type")]
		private string _type;

		[JsonIgnore]
		[NotMapped]
		public TraktLikeType Type {
			get => Helpers.TraktEnumHelper.FromDescription(_type, TraktLikeType.Unspecified);
			set => _type = Helpers.TraktEnumHelper.GetDescription(value);
		}

		[JsonProperty(PropertyName = "comment")]
		public TraktComment Comment { get; set; }

		[JsonProperty(PropertyName = "list")]
		public TraktList List { get; set; }
	}
}