using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Request.Shows;

namespace TraktSharp.Modules {

	public class TraktShowsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktShowsModule(TraktClient client) : base(client) { }

		public async Task<IEnumerable<TraktShow>> GetPopularShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> GetTrendingShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> GetUpdatedShowsAsync(DateTime? startDate = null, ExtendedOption extended = ExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<TraktShow> GetShow(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetShow(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShow> GetShow(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		public async Task<IEnumerable<object>> GetAliasesAsync(TraktShow show) {
			return await GetAliasesAsync(show.Ids.GetBestId());
		}

		public async Task<IEnumerable<object>> GetAliasesAsync(string showId) {
			await Task.Run(() => { throw new NotImplementedException("Trakt: Currently no data to back this. Will be completed when source data has it available."); });
			return null;
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(TraktShow show, string language, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetTranslationsAsync(show.Ids.GetBestId(), language, extended);
		}

		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(string showId, string language, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsTranslationsRequest(Client) {
				Id = showId,
				Language = language,
				Extended = extended
			});
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsCommentsRequest(Client) {
				Id = showId,
				Pagination = new PaginationOptions(page, limit)
			});
		}

		public async Task<TraktShowProgress> GetCollectionProgressAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetCollectionProgressAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> GetCollectionProgressAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsProgressCollectionRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		public async Task<TraktShowProgress> GetWatchedProgressAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetWatchedProgressAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktShowProgress> GetWatchedProgressAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsProgressWatchedRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetCastAndCrewAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktPeople> GetCastAndCrewAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsPeopleRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		public async Task<TraktRatings> GetRatingsAsync(TraktShow show) {
			return await GetRatingsAsync(show.Ids.GetBestId());
		}

		public async Task<TraktRatings> GetRatingsAsync(string showId) {
			return await SendAsync(new TraktShowsRatingsRequest(Client) {
				Id = showId
			});
		}

		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetRelatedShowsAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsRelatedRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		public async Task<object> GetStatsAsync(TraktShow show) {
			return await GetStatsAsync(show.Ids.GetBestId());
		}

		public async Task<object> GetStatsAsync(string showId) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetUsersWatchingShowAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsWatchingRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

	}

}