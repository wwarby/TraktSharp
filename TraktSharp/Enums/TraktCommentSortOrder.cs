using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	public enum TraktCommentSortOrder {

		[Description("newest")]
		Newest,

		[Description("oldest")]
		Oldest,

		[Description("likes")]
		Likes,

		[Description("replies")]
		Replies

	}

}