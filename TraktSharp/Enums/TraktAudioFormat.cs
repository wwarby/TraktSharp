using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp.Enums {

	/// <summary>Options for the audio format metadata on supporting request types</summary>
	public enum TraktAudioFormat {
		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,
		/// <summary>LPCM</summary>
		[Description("lpcm")]
		Lpcm,
		/// <summary>MP3</summary>
		[Description("mp3")]
		Mp3,
		/// <summary>AAC</summary>
		[Description("aac")]
		Aac,
		/// <summary>OGG</summary>
		[Description("ogg")]
		Ogg,
		/// <summary>WMA</summary>
		[Description("wma")]
		Wma,
		/// <summary>DTS</summary>
		[Description("dts")]
		Dts,
		/// <summary>DTS Master-Audio</summary>
		[Description("dts_ma")]
		DtsMa,
		/// <summary>Dolby ProLogic</summary>
		[Description("dolby_prologic")]
		DolbyProLogic,
		/// <summary>Dolby Digital</summary>
		[Description("dolby_digital")]
		DolbyDigital,
		/// <summary>Dolby Digital Plus</summary>
		[Description("dolby_digital_plus")]
		DolbyDigitalPlus,
		/// <summary>Dolby True HD</summary>
		[Description("dolby_truehd")]
		DolbyTrueHd
	}

}