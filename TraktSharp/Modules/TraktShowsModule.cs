using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;
using TraktSharp.Request.Shows;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Shows namespace</summary>
	public class TraktShowsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktShowsModule(TraktClient client) : base(client) { }

		/// <summary>Returns the most popular shows. Popularity is calculated using the rating percentage and the number of ratings.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetPopularShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns all shows being watched right now. Shows with the most users are returned first.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> GetTrendingShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns all shows updated since the specified UTC date. We recommended storing the date you can be efficient using this method moving forward.</summary>
		/// <param name="startDate">Return items updated after this date</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> GetUpdatedShowsAsync(DateTime? startDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns a single shows's details</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShow> GetShowAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetShowAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns a single shows's details</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShow> GetShowAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		/// <summary>Returns all title aliases for a show. Includes country where name is different</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<object>> GetAliasesAsync(TraktShow show) {
			return await GetAliasesAsync(show.Ids.GetBestId());
		}

		/// <summary>Returns all title aliases for a show. Includes country where name is different</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<object>> GetAliasesAsync(string showId) {
			await Task.Run(() => { throw new NotImplementedException("Trakt: Currently no data to back this. Will be completed when source data has it available."); });
			return null;
		}

		/// <summary>Returns all translations for a show, including language and translated values for title and overview</summary>
		/// <param name="show">The show</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(TraktShow show, string language, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetTranslationsAsync(show.Ids.GetBestId(), language, extended);
		}

		/// <summary>Returns all translations for a show, including language and translated values for title and overview</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(string showId, string language, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsTranslationsRequest(Client) {
				Id = showId,
				Language = language,
				Extended = extended
			});
		}

		/// <summary>Returns all top level comments for a show. Most recent comments returned first</summary>
		/// <param name="show">The show</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), page, limit);
		}

		/// <summary>Returns all top level comments for a show. Most recent comments returned first</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int? page = null, int? limit = null) {
			return await SendAsync(new TraktShowsCommentsRequest(Client) {
				Id = showId,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns collection progress for show including details on all seasons and episodes. The next_episode will be the next episode the user should collect, if there are no upcoming episodes it will be set to null.</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetCollectionProgressAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetCollectionProgressAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns collection progress for show including details on all seasons and episodes. The next_episode will be the next episode the user should collect, if there are no upcoming episodes it will be set to null.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetCollectionProgressAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsProgressCollectionRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		/// <summary>Returns watched progress for show including details on all seasons and episodes. The next_episode will be the next episode the user should watch, if there are no upcoming episodes it will be set to null.</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetWatchedProgressAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetWatchedProgressAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns watched progress for show including details on all seasons and episodes. The next_episode will be the next episode the user should watch, if there are no upcoming episodes it will be set to null.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetWatchedProgressAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsProgressWatchedRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		/// <summary>Returns all cast and crew for a show. Each cast member will have a character and a standard person object</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetCastAndCrewAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns all cast and crew for a show. Each cast member will have a character and a standard person object</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsPeopleRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		/// <summary>Returns rating (between 0 and 10) and distribution for a show</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktShow show) {
			return await GetRatingsAsync(show.Ids.GetBestId());
		}

		/// <summary>Returns rating (between 0 and 10) and distribution for a show</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(string showId) {
			return await SendAsync(new TraktShowsRatingsRequest(Client) {
				Id = showId
			});
		}

		/// <summary>Returns related and similar shows</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetRelatedShowsAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns related and similar shows</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsRelatedRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

		/// <summary>Returns lots of show stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(TraktShow show) {
			return await GetStatsAsync(show.Ids.GetBestId());
		}

		/// <summary>Returns lots of show stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(string showId) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		/// <summary>Returns all users watching the show right now</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetUsersWatchingShowAsync(show.Ids.GetBestId(), extended);
		}

		/// <summary>Returns all users watching the show right now</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktShowsWatchingRequest(Client) {
				Id = showId,
				Extended = extended
			});
		}

	}

}