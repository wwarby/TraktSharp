using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the period parameter on supporting request types</summary>
	public enum TraktReportingPeriod {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Weekly</summary>
		[Description("weekly")]
		Weekly,

		/// <summary>Monthly</summary>
		[Description("monthly")]
		Monthly,

		/// <summary>Yearly</summary>
		[Description("yearly")]
		Yearly,

		/// <summary>All</summary>
		[Description("all")]
		All

	}

}