using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Seasons;

namespace TraktSharp.Modules {

	public class TraktSeasonsModule {

		public TraktSeasonsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktSeason> GetSeasonOverviewAsync(TraktShow show, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetSeasonOverviewAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktSeason> GetSeasonOverviewAsync(string showId, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSeasonsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(TraktShow show, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetEpisodesForSeasonAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(TraktShow show, TraktSeason season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetEpisodesForSeasonAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<IEnumerable<TraktEpisode>> GetEpisodesForSeasonAsync(string showId, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSeasonsSeasonRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, int season, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), season, page, limit);
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(TraktShow show, TraktSeason season, int? page = null, int? limit = null) {
			return await GetCommentsAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> GetCommentsAsync(string showId, int season, int? page = null, int? limit = null) {
			return await new TraktSeasonsCommentsRequest(Client) {
				Id = showId,
				Season = season,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktRatings> GetRatingsAsync(TraktShow show, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetRatingsAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<TraktRatings> GetRatingsAsync(TraktShow show, TraktSeason season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetRatingsAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<TraktRatings> GetRatingsAsync(string showId, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSeasonsRatingsRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(TraktShow show, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetUsersWatchingSeasonAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(TraktShow show, TraktSeason season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await GetUsersWatchingSeasonAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<IEnumerable<TraktUser>> GetUsersWatchingSeasonAsync(string showId, int season, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSeasonsWatchingRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

	}

}