using System;
using System.Linq;
using Newtonsoft.Json;

namespace TraktSharp.Response {

	public class TraktComment {

		public TraktComment() {
			User = new TraktUser();
		}

		[JsonProperty(PropertyName = "id")]
		public int? Id { get; set; }

		[JsonProperty(PropertyName = "parent_id")]
		public int? ParentId { get; set; }

		[JsonProperty(PropertyName = "created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonProperty(PropertyName = "comment")]
		public string Comment { get; set; }

		[JsonProperty(PropertyName = "spoiler")]
		public bool Spoiler { get; set; }

		[JsonProperty(PropertyName = "review")]
		public bool Review { get; set; }

		[JsonProperty(PropertyName = "replies")]
		public int? Replies { get; set; }

		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}