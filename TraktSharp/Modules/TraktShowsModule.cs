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

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient" />.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient" /></param>
		public TraktShowsModule(TraktClient client) : base(client) { }

		/// <summary>Returns the most anticipated shows based on the number of lists a show appears on.</summary>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsAnticipatedResponseItem>> GetAnticipatedShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsAnticipatedRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>
		///     Returns the most collected (unique users) shows in the specified time period, defaulting to weekly. All stats
		///     are relative to the specific time period.
		/// </summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsEngagementResponseItem>> GetCollectedShowsAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsCollectedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>
		///     Returns the most played (a single user can watch multiple episodes multiple times) shows in the specified time
		///     period, defaulting to weekly. All stats are relative to the specific time period.
		/// </summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsEngagementResponseItem>> GetPlayedShowsAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsPlayedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>
		///     Returns the most popular shows. Popularity is calculated using the rating percentage and the number of
		///     ratings.
		/// </summary>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetPopularShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsPopularRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns all shows being watched right now. Shows with the most users are returned first.</summary>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTrendingResponseItem>> GetTrendingShowsAsync(TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsTrendingRequest(Client) {
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>
		///     Returns all shows updated since the specified UTC date. We recommended storing the date you can be efficient
		///     using this method moving forward.
		/// </summary>
		/// <param name="startDate">Return items updated after this date</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsUpdatesResponseItem>> GetUpdatedShowsAsync(DateTime? startDate = null, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsUpdatesRequest(Client) {
				StartDate = startDate,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>
		///     Returns the most watched (unique users) shows in the specified time period, defaulting to weekly. All stats
		///     are relative to the specific time period.
		/// </summary>
		/// <param name="period">The reporting period across which to retrieve the results</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsEngagementResponseItem>> GetWatchedShowsAsync(TraktReportingPeriod period = TraktReportingPeriod.Unspecified, TraktExtendedOption extended = TraktExtendedOption.Unspecified, int? page = null, int? limit = null) =>
			await SendAsync(new TraktShowsWatchedRequest(Client) {
				Period = period,
				Extended = extended,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns a single show's details</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShow> GetShowAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetShowAsync(show.Ids.GetBestId(), extended);

		/// <summary>Returns the details for a single show</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShow> GetShowAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktShowsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			});

		/// <summary>Returns all title aliases for a show. Includes country where name is different</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<object>> GetAliasesAsync(TraktShow show) => await GetAliasesAsync(show.Ids.GetBestId());

		/// <summary>Returns all title aliases for a show. Includes country where name is different</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<object>> GetAliasesAsync(string showId) {
			await Task.Run(() => throw new NotImplementedException("Trakt: Currently no data to back this. Will be completed when source data has it available."));
			return null;
		}

		/// <summary>Returns all translations for a show, including language and translated values for title and overview</summary>
		/// <param name="show">The show</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(TraktShow show, string language, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetTranslationsAsync(show.Ids.GetBestId(), language, extended);

		/// <summary>Returns all translations for a show, including language and translated values for title and overview</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="language">2 character language code.Example: <c>es</c>.</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShowsTranslationsResponseItem>> GetTranslationsAsync(string showId, string language, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktShowsTranslationsRequest(Client) {
				Id = showId,
				Language = language,
				Extended = extended
			});

		/// <summary>Returns all top level comments for a show. Most recent comments returned first</summary>
		/// <param name="show">The show</param>
		/// <param name="order">The order in which to sort the results</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, TraktCommentSortOrder order = TraktCommentSortOrder.Newest, int? page = null, int? limit = null) => await GetCommentsAsync(show.Ids.GetBestId(), order, page, limit);

		/// <summary>Returns all top level comments for a show. Most recent comments returned first</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="order">The order in which to sort the results</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, TraktCommentSortOrder order = TraktCommentSortOrder.Newest, int? page = null, int? limit = null) => await SendAsync(new TraktShowsCommentsRequest(Client) {
			Id = showId,
			Order = order,
			Pagination = new TraktPaginationOptions(page, limit)
		});

		/// <summary>
		///     Returns collection progress for show including details on all seasons and episodes. The next_episode will be
		///     the next episode the user should collect, if there are no upcoming episodes it will be set to null.
		/// </summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetCollectionProgressAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetCollectionProgressAsync(show.Ids.GetBestId(), extended);

		/// <summary>
		///     Returns collection progress for show including details on all seasons and episodes. The next_episode will be
		///     the next episode the user should collect, if there are no upcoming episodes it will be set to null.
		/// </summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetCollectionProgressAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await SendAsync(new TraktShowsProgressCollectionRequest(Client) {
			Id = showId,
			Extended = extended
		});

		/// <summary>
		///     Returns watched progress for show including details on all seasons and episodes. The next_episode will be the
		///     next episode the user should watch, if there are no upcoming episodes it will be set to null.
		/// </summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetWatchedProgressAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetWatchedProgressAsync(show.Ids.GetBestId(), extended);

		/// <summary>
		///     Returns watched progress for show including details on all seasons and episodes. The next_episode will be the
		///     next episode the user should watch, if there are no upcoming episodes it will be set to null.
		/// </summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktShowProgress> GetWatchedProgressAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await SendAsync(new TraktShowsProgressWatchedRequest(Client) {
			Id = showId,
			Extended = extended
		});

		/// <summary>Returns all cast and crew for a show. Each cast member will have a character and a standard person object</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetCastAndCrewAsync(show.Ids.GetBestId(), extended);

		/// <summary>Returns all cast and crew for a show. Each cast member will have a character and a standard person object</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktCastAndCrew> GetCastAndCrewAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await SendAsync(new TraktShowsPeopleRequest(Client) {
			Id = showId,
			Extended = extended
		});

		/// <summary>Returns rating (between 0 and 10) and distribution for a show</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktShow show) => await GetRatingsAsync(show.Ids.GetBestId());

		/// <summary>Returns rating (between 0 and 10) and distribution for a show</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(string showId) => await SendAsync(new TraktShowsRatingsRequest(Client) {
			Id = showId
		});

		/// <summary>Returns related and similar shows</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetRelatedShowsAsync(show.Ids.GetBestId(), extended);

		/// <summary>Returns related and similar shows</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetRelatedShowsAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await SendAsync(new TraktShowsRelatedRequest(Client) {
			Id = showId,
			Extended = extended
		});

		/// <summary>Returns lots of show stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(TraktShow show) => await GetStatsAsync(show.Ids.GetBestId());

		/// <summary>Returns lots of show stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(string showId) {
			await Task.Run(() => throw new NotImplementedException("Feature under development at Trakt"));
			return null;
		}

		/// <summary>Returns all users watching the show right now</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetUsersWatchingShowAsync(show.Ids.GetBestId(), extended);

		/// <summary>Returns all users watching the show right now</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">
		///     Changes which properties are populated for standard media objects. By default, minimal data is
		///     returned. Change this if additional fields are required in the returned data.
		/// </param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingShowAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await SendAsync(new TraktShowsWatchingRequest(Client) {
			Id = showId,
			Extended = extended
		});

	}

}