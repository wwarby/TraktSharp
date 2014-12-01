using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the numeric movie ID type on supporting request types</summary>
	public enum TraktNumericMovieIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>TMDb numeric ID</summary>
		Tmdb
	}

}