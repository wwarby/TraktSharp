using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the extended parameter on supporting request types</summary>
	public enum ExtendedOption {
		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,
		/// <summary>Minimal</summary>
		[Description("min")]
		Min,
		/// <summary>Images</summary>
		[Description("images")]
		Images,
		/// <summary>Full</summary>
		[Description("full")]
		Full,
		/// <summary>Full, with images</summary>
		[Description("full,images")]
		FullAndImages
	}

}