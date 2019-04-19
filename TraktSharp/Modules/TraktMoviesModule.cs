using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;
using TraktSharp.Request.Movies;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Movies namespace</summary>
	public class TraktMoviesModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktMoviesModule(TraktClient client) : base(client) { }

		/// <summary>Returns all movies being watched right now. Movies with the most users are returned first.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesAnticipatedResponseItem>> GetAnticipatedMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesAnticipatedRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns the top 10 grossing movies in the U.S. box office last weekend. Updated every Monday morning.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesAnticipatedResponseItem>> GetBoxOfficeMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktMoviesAnticipatedRequest(Client) {
				Extended = extended
			});

		/// <summary>Returns the most collected (unique users) movies in the specified time period, defaulting to weekly. All stats are relative to the specific time period.</summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesEngagementResponseItem>> GetCollectedMoviesAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesCollectedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns the most played (a single user can watch multiple times) movies in the specified time period, defaulting to weekly. All stats are relative to the specific time period.</summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesEngagementResponseItem>> GetPlayedMoviesAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesPlayedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns the most popular movies. Popularity is calculated using the rating percentage and the number of ratings.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMovie>> GetPopularMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesPopularRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns all movies being watched right now. Movies with the most users are returned first.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesTrendingResponseItem>> GetTrendingMoviesAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesTrendingRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns all movies updated since the specified UTC date. We recommended storing the date you can be efficient using this method moving forward.</summary>
		/// <param name="startDate">Return items updated after this date</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesUpdatesResponseItem>> GetUpdatedMoviesAsync(DateTime? startDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns the most watched (unique users) movies in the specified time period, defaulting to weekly. All stats are relative to the specific time period.</summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesEngagementResponseItem>> GetWatchedMoviesAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesWatchedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns a single movie's details</summary>
		/// <param name="movie">The movie</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktMovie> GetMovieAsync(TraktMovie movie, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetMovieAsync(movie.Ids.GetBestId(), extended);

		/// <summary>Returns a single movie's details</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktMovie> GetMovieAsync(string movieId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktMoviesSummaryRequest(Client) {
				Id = movieId,
				Extended = extended
			});

		/// <summary>Returns all title aliases for a movie. Includes country where name is different.</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> GetAliasesAsync(TraktMovie movie) => await GetAliasesAsync(movie.Ids.GetBestId());

		/// <summary>Returns all title aliases for a movie. Includes country where name is different.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> GetAliasesAsync(string movieId) =>
			await SendAsync(new TraktMoviesAliasesRequest(Client) {
				Id = movieId
			});

		/// <summary>Returns all releases for a movie including country, certification, and release date</summary>
		/// <param name="movie">The movie</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> GetReleasesAsync(TraktMovie movie, string language) => await GetReleasesAsync(movie.Ids.GetBestId(), language);

		/// <summary>Returns all releases for a movie including country, certification, and release date</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> GetReleasesAsync(string movieId, string language) =>
			await SendAsync(new TraktMoviesReleasesRequest(Client) {
				Id = movieId,
				Language = language
			});

		/// <summary>Returns all translations for a movie, including language and translated values for title, tagline and overview</summary>
		/// <param name="movie">The movie</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> GetTranslationsAsync(TraktMovie movie, string language) => await GetTranslationsAsync(movie.Ids.GetBestId(), language);

		/// <summary>Returns all translations for a movie, including language and translated values for title, tagline and overview</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> GetTranslationsAsync(string movieId, string language) =>
			await SendAsync(new TraktMoviesTranslationsRequest(Client) {
				Id = movieId,
				Language = language
			});

		/// <summary>Returns all top level comments for a movie. Most recent comments returned first.</summary>
		/// <param name="movie">The movie</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktMovie movie, int? page = null, int? limit = null) => await GetCommentsAsync(movie.Ids.GetBestId(), page, limit);

		/// <summary>Returns all top level comments for a movie. Most recent comments returned first.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string movieId, int? page = null, int? limit = null) =>
			await SendAsync(new TraktMoviesCommentsRequest(Client) {
				Id = movieId,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns all cast and crew for a movie. Each cast member will have a character and a standard person object.</summary>
		/// <param name="movie">The movie</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(TraktMovie movie, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetCastAndCrewAsync(movie.Ids.GetBestId(), extended);

		/// <summary>Returns all cast and crew for a movie. Each cast member will have a character and a standard person object.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(string movieId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktMoviesPeopleRequest(Client) {
				Id = movieId,
				Extended = extended
			});

		/// <summary>Returns rating (between 0 and 10) and distribution for a movie</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktMovie movie) => await GetRatingsAsync(movie.Ids.GetBestId());

		/// <summary>Returns rating (between 0 and 10) and distribution for a movie</summary>
		/// <param name="movieId">The movie ID</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(string movieId) =>
			await SendAsync(new TraktMoviesRatingsRequest(Client) {
				Id = movieId
			});

		/// <summary>Returns related and similar movies</summary>
		/// <param name="movie">The movie</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMovie>> GetRelatedMoviesAsync(TraktMovie movie, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetRelatedMoviesAsync(movie.Ids.GetBestId(), extended);

		/// <summary>Returns related and similar movies</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMovie>> GetRelatedMoviesAsync(string movieId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktMoviesRelatedRequest(Client) {
				Id = movieId,
				Extended = extended
			});

		/// <summary>Returns lots of movie stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(TraktMovie movie) => await GetStatsAsync(movie.Ids.GetBestId());

		/// <summary>Returns lots of movie stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="movieId">The movie ID</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(string movieId) {
			await Task.Run(() => throw new NotImplementedException("Feature under development at Trakt"));
			return null;
		}

		/// <summary>Returns all users watching the movie right now</summary>
		/// <param name="movie">The movie</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingMovieAsync(TraktMovie movie, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetUsersWatchingMovieAsync(movie.Ids.GetBestId(), extended);

		/// <summary>Returns all users watching the movie right now</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingMovieAsync(string movieId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktMoviesWatchingRequest(Client) {
				Id = movieId,
				Extended = extended
			});

	}

}