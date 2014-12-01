using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the media type metadata on supporting request types</summary>
	public enum MediaType {
		/// <summary>Digital</summary>
		[Description("digital")]
		Digital,
		/// <summary>Blu-ray</summary>
		[Description("bluray")]
		BluRay,
		/// <summary>HD-DVD</summary>
		[Description("hddvd")]
		HdDvd,
		/// <summary>DVD</summary>
		[Description("dvd")]
		Dvd,
		/// <summary>VCD</summary>
		[Description("vcd")]
		Vcd,
		/// <summary>VHS</summary>
		[Description("vhs")]
		Vhs,
		/// <summary>Betamax</summary>
		[Description("Betamax")]
		Betamax,
		/// <summary>Laserdisc</summary>
		[Description("Laserdisc")]
		Laserdisc
	}

}