using System;
using System.ComponentModel;
using System.Linq;

namespace TraktSharp {

	/// <summary>OAuth authentication token grant type</summary>
	public enum OAuthTokenGrantType {
		/// <summary>OAuth authorization code grant type</summary>
		[Description("authorization_code")]
		AuthorizationCode,
		/// <summary>OAuth refresh token grant type</summary>
		[Description("refresh_token")]
		RefreshToken
	}

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

	/// <summary>Options for the privacy parameter on supporting request types</summary>
	public enum PrivacyOption {
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

	/// <summary>Options for the rating parameter on supporting request types</summary>
	public enum Rating {
		/// <summary>Rating 0 (unrated)</summary>
		RatingUnspecified = 0,
		/// <summary>Rating 1</summary>
		Rating1 = 1,
		/// <summary>Rating 2</summary>
		Rating2 = 2,
		/// <summary>Rating 3</summary>
		Rating3 = 3,
		/// <summary>Rating 4</summary>
		Rating4 = 4,
		/// <summary>Rating 5</summary>
		Rating5 = 5,
		/// <summary>Rating 6</summary>
		Rating6 = 6,
		/// <summary>Rating 7</summary>
		Rating7 = 7,
		/// <summary>Rating 8</summary>
		Rating8 = 8,
		/// <summary>Rating 9</summary>
		Rating9 = 9,
		/// <summary>Rating 10</summary>
		Rating10 = 10
	}

	/// <summary>Indicates the requirement for OAuth authentication on a request type</summary>
	public enum OAuthRequirement {
		/// <summary>Including authentication headers will not cause an error, but they serve no purpose in this context</summary>
		NotRequired,
		/// <summary>Request type allows authentication headers, but they are optional</summary>
		Optional,
		/// <summary>Request type requires authentication headers</summary>
		Required,
		/// <summary>Request type does not allow authentication headers</summary>
		Forbidden
	}

	/// <summary>Options for the genre type parameter on supporting request types</summary>
	public enum GenreTypeOptions {
		/// <summary>Shows</summary>
		[Description("shows")]
		Shows,
		/// <summary>Movies</summary>
		[Description("movies")]
		Movies
	}

	/// <summary>Options for the rating parameter on supporting request types</summary>
	public enum TextQueryType {
		/// <summary>Unspecified</summary>
		[Description("")]
		Unspecified,
		/// <summary>Movie</summary>
		[Description("movie")]
		Movie,
		/// <summary>Show</summary>
		[Description("show")]
		Show,
		/// <summary>Episode</summary>
		[Description("episode")]
		Episode,
		/// <summary>Person</summary>
		[Description("person")]
		Person,
		/// <summary>List</summary>
		[Description("list")]
		List
	}

	/// <summary>Options for the type of ID lookup on supporting request types</summary>
	public enum IdLookupType {
		/// <summary>Trakt numeric movie ID</summary>
		[Description("trakt-movie")]
		TraktMovie,
		/// <summary>Trakt numeric show ID</summary>
		[Description("trakt-show")]
		TraktShow,
		/// <summary>Trakt numeric episode ID</summary>
		[Description("trakt-episode")]
		TraktEpisode,
		/// <summary>Internet Movie Database ID</summary>
		[Description("imdb")]
		Imdb,
		/// <summary>TMDb numeric ID</summary>
		[Description("tmdb")]
		Tmdb,
		/// <summary>The TVDb numeric ID</summary>
		[Description("tvdb")]
		Tvdb,
		/// <summary>TVRage numeric ID</summary>
		[Description("tvrage")]
		TvRage
	}

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

	/// <summary>Options for the resolution metadata on supporting request types</summary>
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

	/// <summary>Options for the audio format metadata on supporting request types</summary>
	public enum AudioFormat {
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

	/// <summary>Options for the text movie ID type on supporting request types</summary>
	public enum StringMovieIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

	/// <summary>Options for the numeric movie ID type on supporting request types</summary>
	public enum IntMovieIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>TMDb numeric ID</summary>
		Tmdb
	}

	/// <summary>Options for the text show ID type on supporting request types</summary>
	public enum StringShowIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

	/// <summary>Options for the numeric season ID type on supporting request types</summary>
	public enum IntShowIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>The TVDb numeric ID</summary>
		Tvdb,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

	/// <summary>Options for the numeric season ID type on supporting request types</summary>
	public enum IntSeasonIdType {
		/// <summary>The TVDb numeric ID</summary>
		Tvdb,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

	/// <summary>Options for thetext  episode ID type on supporting request types</summary>
	public enum StringEpisodeIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

	/// <summary>Options for the numeric episode ID type on supporting request types</summary>
	public enum IntEpisodeIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>The TVDb numeric ID</summary>
		Tvdb,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

	/// <summary>Options for the text person ID type on supporting request types</summary>
	public enum StringPersonIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug,
		/// <summary>Internet Movie Database ID</summary>
		Imdb
	}

	/// <summary>Options for the numeric person ID type on supporting request types</summary>
	public enum IntPersonIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt,
		/// <summary>TMDb numeric ID</summary>
		Tmdb,
		/// <summary>TVRage numeric ID</summary>
		TvRage
	}

	/// <summary>Options for the text list ID type on supporting request types</summary>
	public enum StringListIdType {
		/// <summary>Automatically detect ID type</summary>
		Auto,
		/// <summary>Trakt URL slug</summary>
		Slug
	}

	/// <summary>Options for the numeric list ID type on supporting request types</summary>
	public enum IntListIdType {
		/// <summary>Trakt numeric ID</summary>
		Trakt
	}

}