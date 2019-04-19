using System.ComponentModel;

namespace TraktSharp.Enums {

	/// <summary>Options for the genre type parameter on supporting request types</summary>
	public enum TraktGenreTypeOptions {
		/// <summary>Shows</summary>
		[Description("shows")]
		Shows,
		/// <summary>Movies</summary>
		[Description("movies")]
		Movies
	}

}