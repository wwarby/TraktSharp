using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the rating parameter on supporting request types</summary>
	public enum TraktWatchingItemType {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Movie</summary>
		[Description("movie")]
		Movie,

		/// <summary>Show</summary>
		[Description("show")]
		Show,

		/// <summary>Episode</summary>
		[Description("episode")]
		Episode

	}

}