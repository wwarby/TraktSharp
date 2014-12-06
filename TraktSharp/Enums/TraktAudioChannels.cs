using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the audio channels metadata on supporting request types</summary>
	public enum TraktAudioChannels {
		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,
		/// <summary>1.0</summary>
		[Description("1.0")]
		Channels10,
		/// <summary>2.0</summary>
		[Description("2.0")]
		Channels20,
		/// <summary>2.1</summary>
		[Description("2.1")]
		Channels21,
		/// <summary>3.0</summary>
		[Description("3.0")]
		Channels30,
		/// <summary>3.1</summary>
		[Description("3.1")]
		Channels31,
		/// <summary>4.0</summary>
		[Description("4.0")]
		Channels40,
		/// <summary>4.1</summary>
		[Description("4.1")]
		Channels41,
		/// <summary>5.0</summary>
		[Description("5.0")]
		Channels50,
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