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

		public async Task<IEnumerable<TraktShow>> GetPopularShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> GetTrendingShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> GetUpdatedShowsAsync(DateTime? startDate = null, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktShow> GetShow(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetShow(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShow> GetShow(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(TraktShow show, string language, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetTranslationsAsync(show.Ids.GetBestId(), language, extended);
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(string showId, string language, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsTranslationsRequest(Client) {
				Id = showId,
				Language = language,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int? page = null, int? limit = null) {
			return await new TraktShowsCommentsRequest(Client) {
				Id = showId,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktShowProgress> GetCollectionProgressAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetCollectionProgressAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> GetCollectionProgressAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsProgressCollectionRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktShowProgress> GetWatchedProgressAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetWatchedProgressAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> GetWatchedProgressAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsProgressWatchedRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetCastAndCrewAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsPeopleRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> GetRatingsAsync(TraktShow show) {
			return await GetRatingsAsync(show.Ids.GetBestId());
		}

		public async Task<TraktRatings> GetRatingsAsync(string showId) {
			return await new TraktShowsRatingsRequest(Client) {
				Id = showId
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetRelatedShowsAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsRelatedRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetUsersWatchingShowAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktShowsWatchingRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

	}

}