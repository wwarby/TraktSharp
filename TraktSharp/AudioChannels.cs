using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	/// <summary>Options for the audio channels metadata on supporting request types</summary>
	public enum AudioChannels {
		/// <summary>1.0</summary>
		[Description("1.0")]
		Channels10,
		/// <summary>2.0</summary>
		[Description("2.0")]
		Channels20,
		/// <summary>5.1</summary>
		[Description("5.1")]
		Channels51,
		/// <summary>6.1</summary>
		[Description("6.1")]
		Channels61,
		/// <summary>7.1</summary>
		[Description("7.1")]
		Channels71
	}

}