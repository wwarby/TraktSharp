using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	public enum OAuthTokenGrantType {
		[Description("authorization_code")]
		AuthorizationCode,
		[Description("refresh_token")]
		RefreshToken
	}

	public enum ExtendedOption {
		[Description("")]
		Unspecified,
		[Description("min")]
		Min,
		[Description("images")]
		Images,
		[Description("full")]
		Full,
		[Description("full,images")]
		FullAndImages
	}

	public enum PrivacyOption {
		[Description("")]
		Unspecified,
		[Description("private")]
		Private,
		[Description("friends")]
		Friends,
		[Description("public")]
		Public
	}

	public enum Rating {
		RatingUnspecified = 0,
		Rating1 = 1,
		Rating2 = 2,
		Rating3 = 3,
		Rating4 = 4,
		Rating5 = 5,
		Rating6 = 6,
		Rating7 = 7,
		Rating8 = 8,
		Rating9 = 9,
		Rating10 = 10
	}

	public enum OAuthRequirement { NotRequired, Optional, Required, Forbidden }

	public enum GenreTypeOptions {
		[Description("shows")]
		Shows,
		[Description("movies")]
		Movies
	}

	public enum TextQueryType {
		[Description("")]
		Unspecified,
		[Description("movie")]
		Movie,
		[Description("show")]
		Show,
		[Description("episode")]
		Episode,
		[Description("person")]
		Person,
		[Description("list")]
		List
	}

	public enum IdLookupType {
		[Description("trakt-movie")]
		TraktMovie,
		[Description("trakt-show")]
		TraktShow,
		[Description("trakt-episode")]
		TraktEpisode,
		[Description("imdb")]
		Imdb,
		[Description("tmdb")]
		Tmdb,
		[Description("tvdb")]
		Tvdb,
		[Description("tvrage")]
		TvRage
	}

	public enum MediaType {
		[Description("digital")]
		Digital,
		[Description("bluray")]
		BluRay,
		[Description("hddvd")]
		HdDvd,
		[Description("dvd")]
		Dvd,
		[Description("vcd")]
		Vcd,
		[Description("vhs")]
		Vhs,
		[Description("Betamax")]
		Betamax,
		[Description("Laserdisc")]
		Laserdisc
	}

	public enum Resolution {
		[Description("uhd_4k")]
		Uhd4k,
		[Description("hd_1080p")]
		Hd1080p,
		[Description("hd_1080i")]
		Hd1080i,
		[Description("hd_720p")]
		Hd720p,
		[Description("sd_480p")]
		Sd480p,
		[Description("sd_480i")]
		Sd480i,
		[Description("sd_576p")]
		Sd576p,
		[Description("sd_576i")]
		Sd576i
	}

	public enum AudioFormat {
		[Description("lpcm")]
		Lpcm,
		[Description("mp3")]
		Mp3,
		[Description("acc")]
		Acc,
		[Description("ogg")]
		Ogg,
		[Description("wma")]
		Wma,
		[Description("dts")]
		Dts,
		[Description("dts_ma")]
		DtsMa,
		[Description("dolby_prologic")]
		DolbyProLogic,
		[Description("dolby_digital")]
		DolbyDigital,
		[Description("dolby_digital_plus")]
		DolbyDigitalPlus,
		[Description("dolby_truehd")]
		DolbyTrueHd
	}

	public enum AudioChannels {
		[Description("1.0")]
		Channels10,
		[Description("2.0")]
		Channels20,
		[Description("5.1")]
		Channels51,
		[Description("6.1")]
		Channels61,
		[Description("7.1")]
		Channels71
	}

	public enum StringMovieIdType { Auto, Slug, Imdb }
	
	public enum IntMovieIdType { Trakt, Tmdb }

	public enum StringEpisodeIdType { Auto, Imdb }

	public enum IntEpisodeIdType { Trakt, Tvdb, Tmdb, TvRage }

	public enum StringShowIdType { Auto, Slug, Imdb }

	public enum IntShowIdType { Trakt, Tvdb, Tmdb, TvRage }

	public enum StringListIdType { Auto, Slug }

	public enum IntListIdType { Trakt }

}