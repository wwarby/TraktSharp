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

		public async Task<IEnumerable<TraktMovie>> PopularAsync(ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesTrendingResponseItem>> TrendingAsync(ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesUpdatesResponseItem>> UpdatesAsync(DateTime? startDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktMovie> SummaryAsync(TraktMovie movie, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await SummaryAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<TraktMovie> SummaryAsync(string movieId, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesSummaryRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> AliasesAsync(TraktMovie movie) {
			return await AliasesAsync(movie.Ids.GetBestId());
		}

		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> AliasesAsync(string movieId) {
			return await new TraktMoviesAliasesRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> ReleasesAsync(TraktMovie movie, string language) {
			return await ReleasesAsync(movie.Ids.GetBestId(), language);
		}

		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> ReleasesAsync(string movieId, string language) {
			return await new TraktMoviesReleasesRequest(Client) {
				Id = movieId,
				Language = language
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> TranslationsAsync(TraktMovie movie, string language) {
			return await TranslationsAsync(movie.Ids.GetBestId(), language);
		}

		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> TranslationsAsync(string movieId, string language) {
			return await new TraktMoviesTranslationsRequest(Client) {
				Id = movieId,
				Language = language
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktMovie movie, int? page = null, int? limit = null) {
			return await CommentsAsync(movie.Ids.GetBestId(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string movieId, int? page = null, int? limit = null) {
			return await new TraktMoviesCommentsRequest(Client) {
				Id = movieId,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktPeople> PeopleAsync(TraktMovie movie, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await PeopleAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<TraktPeople> PeopleAsync(string movieId, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesPeopleRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(TraktMovie movie) {
			return await RatingsAsync(movie.Ids.GetBestId());
		}

		public async Task<TraktRatings> RatingsAsync(string movieId) {
			return await new TraktMoviesRatingsRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMovie>> RelatedAsync(TraktMovie movie, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await RelatedAsync(movie.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktMovie>> RelatedAsync(string movieId, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesRelatedRequest(Client) {
				Id = movieId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktMovie movie) {
			return await WatchingAsync(movie.Ids.GetBestId());
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string movieId) {
			return await new TraktMoviesWatchingRequest(Client) {
				Id = movieId
			}.SendAsync();
		}

	}

}