using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the rating parameter on supporting request types</summary>
	public enum TextQueryType {
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
		Episode,
		/// <summary>Person</summary>
		[Description("person")]
		Person,
		/// <summary>List</summary>
		[Description("list")]
		List
	}

}