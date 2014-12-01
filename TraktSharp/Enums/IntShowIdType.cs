using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the numeric season ID type on supporting request types</summary>
	public enum IntShowIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>The TVDb numeric ID</summary>
		Tvdb,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

}