using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Enums;
using TraktSharp.Request.Episodes;
using TraktSharp.Structs;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Episodes namespace</summary>
	public class TraktEpisodesModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktEpisodesModule(TraktClient client) : base(client) { }

		/// <summary>Returns a single episode's details. All date and times are in UTC and were calculated using the episode's air_date and show's country and air_time.</summary>
		/// <param name="show">The show</param>
		/// <param name="episode">The episode</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktEpisode> GetEpisodeAsync(TraktShow show, TraktEpisode episode, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetEpisodeAsync(show.Ids.GetBestId(), episode.SeasonNumber.GetValueOrDefault(), episode.EpisodeNumber.GetValueOrDefault(), extended);
		}

		/// <summary>Returns a single episode's details. All date and times are in UTC and were calculated using the episode's air_date and show's country and air_time.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktEpisode> GetEpisodeAsync(string showId, int seasonNumber, int episodeNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktEpisodesSummaryRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Episode = episodeNumber,
				Extended = extended
			});
		}

		/// <summary>Returns all top level comments for an episode. Most recent comments returned first.</summary>
		/// <param name="show">The show</param>
		/// <param name="episode">The episode</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, TraktEpisode episode, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), episode.SeasonNumber.GetValueOrDefault(), episode.EpisodeNumber.GetValueOrDefault(), page, limit);
		}

		/// <summary>Returns all top level comments for an episode. Most recent comments returned first.</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="page">The page number</param>
		/// <param name="limit">The number of records to show per page</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int seasonNumber, int episodeNumber, int? page = null, int? limit = null) {
			return await SendAsync(new TraktEpisodesCommentsRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Episode = episodeNumber,
				Pagination = new TraktPaginationOptions(page, limit)
			});
		}

		/// <summary>Returns rating (between 0 and 10) and distribution for an episode</summary>
		/// <param name="show">The show</param>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(TraktShow show, TraktEpisode episode) {
			return await GetRatingsAsync(show.Ids.GetBestId(), episode.SeasonNumber.GetValueOrDefault(), episode.EpisodeNumber.GetValueOrDefault());
		}

		/// <summary>Returns rating (between 0 and 10) and distribution for an episode</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <returns>See summary</returns>
		public async Task<TraktRatings> GetRatingsAsync(string showId, int seasonNumber, int episodeNumber) {
			return await SendAsync(new TraktEpisodesRatingsRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Episode = episodeNumber
			});
		}

		/// <summary>Returns lots of episode stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="show">The show</param>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(TraktShow show, TraktEpisode episode) {
			return await GetStatsAsync(show.Ids.GetBestId(), episode.SeasonNumber.GetValueOrDefault(), episode.EpisodeNumber.GetValueOrDefault());
		}

		/// <summary>Returns lots of episode stats including ratings breakdowns, scrobbles, checkins, collections, lists, and comments</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <returns>See summary</returns>
		public async Task<object> GetStatsAsync(string showId, int seasonNumber, int episodeNumber) {
			await Task.Run(() => { throw new NotImplementedException("Feature under development at Trakt"); });
			return null;
		}

		/// <summary>Returns all users watching the episode right now</summary>
		/// <param name="show">The show</param>
		/// <param name="episode">The episode</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingEpisodeAsync(TraktShow show, TraktEpisode episode, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await GetUsersWatchingEpisodeAsync(show.Ids.GetBestId(), episode.SeasonNumber.GetValueOrDefault(), episode.EpisodeNumber.GetValueOrDefault(), extended);
		}

		/// <summary>Returns all users watching the episode right now</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktUser>> GetUsersWatchingEpisodeAsync(string showId, int seasonNumber, int episodeNumber, TraktExtendedOption extended = TraktExtendedOption.Unspecified) {
			return await SendAsync(new TraktEpisodesWatchingRequest(Client) {
				Id = showId,
				Season = seasonNumber,
				Episode = episodeNumber,
				Extended = extended
			});
		}

	}

}