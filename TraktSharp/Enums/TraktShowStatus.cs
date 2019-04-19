using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Production statuses for a show</summary>
	public enum TraktShowStatus {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Returning Series</summary>
		[Description("returning series")]
		ReturningSeries,

		/// <summary>In production</summary>
		[Description("in production")]
		InProduction,

		/// <summary>Canceled</summary>
		[Description("canceled")]
		Canceled,

		/// <summary>Ended</summary>
		[Description("ended")]
		Ended

	}

}