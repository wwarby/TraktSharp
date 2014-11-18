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

	public enum ExtendedOptions {
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

	public enum OAuthRequirementOptions {
		NotRequired,
		Optional,
		Required,
		Forbidden
	}

	public enum GenreTypeOptions {
		[Description("shows")]
		Shows,
		[Description("movies")]
		Movies
	}

	public enum TextQueryTypeOptions {
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

	public enum IdLookupTypeOptions {
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

}