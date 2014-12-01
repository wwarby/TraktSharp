using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the resolution metadata on supporting request types</summary>
	// ReSharper disable InconsistentNaming
	public enum Resolution {
		/// <summary>4K (UHD)</summary>
		[Description("uhd_4k")]
		Uhd4k,
		/// <summary>1080p (HD)</summary>
		[Description("hd_1080p")]
		Hd1080p,
		/// <summary>1080i (HD)</summary>
		[Description("hd_1080i")]
		Hd1080i,
		/// <summary>720p (HD)</summary>
		[Description("hd_720p")]
		Hd720p,
		/// <summary>480p (SD)</summary>
		[Description("sd_480p")]
		Sd480p,
		/// <summary>480i (SD)</summary>
		[Description("sd_480i")]
		Sd480i,
		/// <summary>576p (SD)</summary>
		[Description("sd_576p")]
		Sd576p,
		/// <summary>576i (SD)</summary>
		[Description("sd_576i")]
		Sd576i
	}

}