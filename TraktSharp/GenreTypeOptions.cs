using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the genre type parameter on supporting request types</summary>
	public enum GenreTypeOptions {
		/// <summary>Shows</summary>
		[Description("shows")]
		Shows,
		/// <summary>Movies</summary>
		[Description("movies")]
		Movies
	}

}