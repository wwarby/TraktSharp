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

		public async Task<TraktSeason> SummaryAsync(TraktShow show, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await SummaryAsync(show.Ids.GetBestId(), extended);
		}

		public async Task<TraktSeason> SummaryAsync(string showId, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsSummaryRequest(Client) {
				Id = showId,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktEpisode>> SeasonAsync(TraktShow show, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await SeasonAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<IEnumerable<TraktEpisode>> SeasonAsync(TraktShow show, TraktSeason season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await SeasonAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<IEnumerable<TraktEpisode>> SeasonAsync(string showId, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsSeasonRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktShow show, int season, int? page = null, int? limit = null) {
			return await CommentsAsync(show.Ids.GetBestId(), season, page, limit);
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktShow show, TraktSeason season, int? page = null, int? limit = null) {
			return await CommentsAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string showId, int season, int? page = null, int? limit = null) {
			return await new TraktSeasonsCommentsRequest(Client) {
				Id = showId,
				Season = season,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(TraktShow show, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await RatingsAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<TraktRatings> RatingsAsync(TraktShow show, TraktSeason season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await RatingsAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<TraktRatings> RatingsAsync(string showId, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsRatingsRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktShow show, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await WatchingAsync(show.Ids.GetBestId(), season, extended);
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktShow show, TraktSeason season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await WatchingAsync(show.Ids.GetBestId(), season.Number.GetValueOrDefault(), extended);
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string showId, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsWatchingRequest(Client) {
				Id = showId,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

	}

}