using System;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the numeric person ID type on supporting request types</summary>
	public enum IntPersonIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

}