using System;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the text movie ID type on supporting request types</summary>
	public enum StringMovieIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

}