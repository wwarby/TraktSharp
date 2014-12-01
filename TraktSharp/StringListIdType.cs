using System;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the text list ID type on supporting request types</summary>
	public enum StringListIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug
	}

}