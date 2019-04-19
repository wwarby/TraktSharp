using System.ComponentModel;

namespace TraktSharp.Enums {

	/// <summary>Options for the type of media object in a text query search</summary>
	public enum TraktSearchItemType {
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