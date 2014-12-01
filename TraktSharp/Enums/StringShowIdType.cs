using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the text show ID type on supporting request types</summary>
	public enum StringShowIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

}