using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the privacy parameter on supporting request types</summary>
	public enum TraktPrivacyOption {

		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,

		/// <summary>Private</summary>
		[Description("private")]
		Private,

		/// <summary>Friends</summary>
		[Description("friends")]
		Friends,

		/// <summary>Public</summary>
		[Description("public")]
		Public

	}

}