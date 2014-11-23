using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Request.Movies;

namespace TraktSharp.Modules {

	public class TraktMoviesModule {

		public TraktMoviesModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktMovie>> GetPopularMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesTrendingResponseItem>> GetTrendingMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesUpdatesResponseItem>> GetUpdatedMoviesAsync(DateTime? startDate = null, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktMovie> GetMovieAsync(TraktMovie movie, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetMovieAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<TraktMovie> GetMovieAsync(string movieId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktMoviesSummaryRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> GetAliasesAsync(TraktMovie movie) {
			return await GetAliasesAsync(movie.Ids.GetBestId());
		}

		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> GetAliasesAsync(string movieId) {
			return await new TraktMoviesAliasesRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> GetReleasesAsync(TraktMovie movie, string language) {
			return await GetReleasesAsync(movie.Ids.GetBestId(), language);
		}

		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> GetReleasesAsync(string movieId, string language) {
			return await new TraktMoviesReleasesRequest(Client) {
				Id = movieId,
				Language = language
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> GetTranslationsAsync(TraktMovie movie, string language) {
			return await GetTranslationsAsync(movie.Ids.GetBestId(), language);
		}

		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> GetTranslationsAsync(string movieId, string language) {
			return await new TraktMoviesTranslationsRequest(Client) {
				Id = movieId,
				Language = language
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktMovie movie, int? page = null, int? limit = null) {
			return await GetCommentsAsync(movie.Ids.GetBestId(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string movieId, int? page = null, int? limit = null) {
			return await new TraktMoviesCommentsRequest(Client) {
				Id = movieId,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(TraktMovie movie, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetCastAndCrewAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(string movieId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktMoviesPeopleRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> GetRatingsAsync(TraktMovie movie) {
			return await GetRatingsAsync(movie.Ids.GetBestId());
		}

		public async Task<TraktRatings> GetRatingsAsync(string movieId) {
			return await new TraktMoviesRatingsRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMovie>> GetRelatedMoviesAsync(TraktMovie movie, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetRelatedMoviesAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktMovie>> GetRelatedMoviesAsync(string movieId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktMoviesRelatedRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingMovieAsync(TraktMovie movie) {
			return await GetUsersWatchingMovieAsync(movie.Ids.GetBestId());
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingMovieAsync(string movieId) {
			return await new TraktMoviesWatchingRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

	}

}