using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Request.Movies;
using TraktSharp.Request.Shows;

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

		public async Task<TraktMovie> SummaryAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesSummaryRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesAliasesResponseItem>> AliasesAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesAliasesRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesReleasesResponseItem>> ReleasesAsync(string id, string language, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesReleasesRequest(Client) {
				Id = id,
				Language = language,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMoviesTranslationsResponseItem>> TranslationsAsync(string id, string language, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesTranslationsRequest(Client) {
				Id = id,
				Language = language,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktMoviesCommentsRequest(Client) {
				Id = id,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktPeople> PeopleAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesPeopleRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesRatingsRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktMovie>> RelatedAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesRelatedRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktMoviesWatchingRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

	}

}