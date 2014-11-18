using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.Shows;
using TraktSharp.Response;
using TraktSharp.Response.Shows;

namespace TraktSharp.Modules {

	public class TraktShows {

		public TraktShows(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktShow>> PopularAsync(ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> TrendingAsync(ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> UpdatesAsync(DateTime? startDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktShow> SummaryAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsSummaryRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> TranslationsAsync(string id, string language, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsTranslationsRequest(Client) {
				Id = id,
				Language = language,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsCommentsRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowProgress> ProgressCollectionAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsProgressCollectionRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowProgress> ProgressWatchedAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsProgressWatchedRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktPeople> PeopleAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsPeopleRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsRatingsRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> RelatedAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsRelatedRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktShowsWatchingRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

	}

}