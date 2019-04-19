using System.ComponentModel;

namespace TraktSharp.Enums {

	/// <summary>Options for watched history actions</summary>
	public enum TraktHistoryAction {
		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,
		/// <summary>Watch</summary>
		[Description("watch")]
		Watch,
		/// <summary>Checkin</summary>
		[Description("checkin")]
		Checkin,
		/// <summary>Scrobble</summary>
		[Description("scrobble")]
		Scrobble
	}

}