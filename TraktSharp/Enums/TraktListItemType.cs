using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the type of media object in a list</summary>
	public enum TraktListItemType {
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
		Person
	}

}