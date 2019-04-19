using System.ComponentModel;

namespace TraktSharp.Enums {

	/// <summary>Options for the type of ID lookup on supporting request types</summary>
	public enum TraktIdLookupType {
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

}