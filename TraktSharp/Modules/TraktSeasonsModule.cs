using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Request.Seasons;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Seasons namespace</summary>
	public class TraktSeasonsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktSeasonsModule(TraktClient client) : base(client) { }

		/// <summary>Returns all seasons for a show including the number of episodes in each season</summary>
		/// <param name="show">The show</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktSeason>> GetSeasonOverviewAsync(TraktShow show, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetSeasonOverviewAsync(show.Ids.GetBestId(), extended);

		/// <summary>Returns all seasons for a show including the number of episodes in each season</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktSeason>> GetSeasonOverviewAsync(string showId, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktSeasonsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			});

		/// <summary>Returns all episodes for a specific season of a show</summary>
		/// <param name="show">The show</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(TraktShow show, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetEpisodesForSeasonAsync(show.Ids.GetBestId(), seasonNumber, extended);

		/// <summary>Returns all episodes for a specific season of a show</summary>
		/// <param name="show">The show</param>
		/// <param name="season">The season</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(TraktShow show, TraktSeason season, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetEpisodesForSeasonAsync(show.Ids.GetBestId(), season.SeasonNumber.GetValueOrDefault(), extended);

		/// <summary>Returns all episodes for a specific season of a show</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(string showId, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktSeasonsSeasonRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Extended = extended
			});

		/// <summary>Returns all top level comments for a season. Most recent comments returned first.</summary>
		/// <param name="show">The show</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, int seasonNumber, int? page = null, int? limit = null) => await GetCommentsAsync(show.Ids.GetBestId(), seasonNumber, page, limit);

		/// <summary>Returns all top level comments for a season. Most recent comments returned first.</summary>
		/// <param name="show">The show</param>
		/// <param name="season">The season</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, TraktSeason season, int? page = null, int? limit = null) => await GetCommentsAsync(show.Ids.GetBestId(), season.SeasonNumber.GetValueOrDefault(), page, limit);

		/// <summary>Returns all top level comments for a season. Most recent comments returned first.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int seasonNumber, int? page = null, int? limit = null) =>
			await SendAsync(new TraktSeasonsCommentsRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Pagination = new TraktPaginationOptions(page, limit)
			});

		/// <summary>Returns rating (between 0 and 10) and distribution for a season</summary>
		/// <param name="show">The show</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktShow show, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetRatingsAsync(show.Ids.GetBestId(), seasonNumber, extended);

		/// <summary>Returns rating (between 0 and 10) and distribution for a season</summary>
		/// <param name="show">The show</param>
		/// <param name="season">The season</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktShow show, TraktSeason season, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetRatingsAsync(show.Ids.GetBestId(), season.SeasonNumber.GetValueOrDefault(), extended);

		/// <summary>Returns rating (between 0 and 10) and distribution for a season</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(string showId, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktSeasonsRatingsRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Extended = extended
			});

		/// <summary>Returns all users watching this season right now</summary>
		/// <param name="show">The show</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(TraktShow show, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetUsersWatchingSeasonAsync(show.Ids.GetBestId(), seasonNumber, extended);

		/// <summary>Returns all users watching this season right now</summary>
		/// <param name="show">The show</param>
		/// <param name="season">The season</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(TraktShow show, TraktSeason season, TraktExtendedOption extended = TraktExtendedOption.Unspecified) => await GetUsersWatchingSeasonAsync(show.Ids.GetBestId(), season.SeasonNumber.GetValueOrDefault(), extended);

		/// <summary>Returns all users watching this season right now</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(string showId, int seasonNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) =>
			await SendAsync(new TraktSeasonsWatchingRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Extended = extended
			});

	}

}