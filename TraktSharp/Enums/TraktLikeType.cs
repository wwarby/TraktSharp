using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the rating parameter on supporting request types</summary>
	public enum TraktLikeType {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Comments</summary>
		[Description("comment")]
		Comments,

		/// <summary>Lists</summary>
		[Description("list")]
		Lists

	}

}