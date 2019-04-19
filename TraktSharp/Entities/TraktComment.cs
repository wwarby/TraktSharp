using System;
using Newtonsoft.Json;

namespace TraktSharp.Entities {

	/// <summary>A comment from a user</summary>
	[Serializable]
	public class TraktComment {

		/// <summary>The comment ID</summary>
		[JsonProperty(PropertyName = "id")]
		public int? Id { get; set; }

		/// <summary>The ID of the parent comment to which this comment is a reply</summary>
		[JsonProperty(PropertyName = "parent_id")]
		public int? ParentId { get; set; }

		/// <summary>The UTC date when the comment was posted</summary>
		[JsonProperty(PropertyName = "created_at")]
		public DateTimeOffset? CreatedAt { get; set; }

		/// <summary>The comment text</summary>
		[JsonProperty(PropertyName = "comment")]
		public string Comment { get; set; }

		/// <summary><c>true</c> if the comment contains spoilers</summary>
		[JsonProperty(PropertyName = "spoiler")]
		public bool? Spoiler { get; set; }

		/// <summary><c>true</c> if the comment is a review</summary>
		[JsonProperty(PropertyName = "review")]
		public bool? Review { get; set; }

		/// <summary>The number of replies that exist for this comment</summary>
		[JsonProperty(PropertyName = "replies")]
		public int? Replies { get; set; }

		/// <summary>The number of users who like this comment</summary>
		[JsonProperty(PropertyName = "likes")]
		public int? Likes { get; set; }

		/// <summary>The user who posted the comment</summary>
		[JsonProperty(PropertyName = "user")]
		public TraktUser User { get; set; }

	}

}