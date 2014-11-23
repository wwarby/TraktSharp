using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Request.Shows;

namespace TraktSharp.Modules {

	public class TraktShowsModule {

		public TraktShowsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktShow>> PopularAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> TrendingAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> UpdatesAsync(DateTime? startDate = null, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktShow> SummaryAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SummaryAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShow> SummaryAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> TranslationsAsync(TraktShow show, string language) {
			return await TranslationsAsync(show.Ids.GetBestId(), language);
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> TranslationsAsync(string showId, string language, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsTranslationsRequest(Client) {
				Id = showId,
				Language = language,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktShow show, int? page = null, int? limit = null) {
			return await CommentsAsync(show.Ids.GetBestId(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string showId, int? page = null, int? limit = null) {
			return await new TraktShowsCommentsRequest(Client) {
				Id = showId,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktShowProgress> ProgressCollectionAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await ProgressCollectionAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> ProgressCollectionAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsProgressCollectionRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowProgress> ProgressWatchedAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await ProgressWatchedAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> ProgressWatchedAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsProgressWatchedRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktPeople> PeopleAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await PeopleAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktPeople> PeopleAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsPeopleRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(TraktShow show) {
			return await RatingsAsync(show.Ids.GetBestId());
		}

		public async Task<TraktRatings> RatingsAsync(string showId) {
			return await new TraktShowsRatingsRequest(Client) {
				Id = showId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> RelatedAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await RelatedAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktShow>> RelatedAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsRelatedRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktShow show) {
			return await WatchingAsync(show.Ids.GetBestId());
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string showId) {
			return await new TraktShowsWatchingRequest(Client) {
				Id = showId
			}.SendAsync();
		}

	}

}