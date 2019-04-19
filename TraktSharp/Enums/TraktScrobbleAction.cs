using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for scrobble actions</summary>
	public enum TraktScrobbleAction {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Start</summary>
		[Description("start")]
		Start,

		/// <summary>Pause</summary>
		[Description("pause")]
		Pause,

		/// <summary>Scrobble</summary>
		[Description("scrobble")]
		Scrobble

	}

}