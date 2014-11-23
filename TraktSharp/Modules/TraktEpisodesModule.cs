using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Episodes;

namespace TraktSharp.Modules {

	public class TraktEpisodesModule {

		public TraktEpisodesModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktEpisode> SummaryAsync(TraktShow show, TraktEpisode episode, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SummaryAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault(), extended);
		}

		public async Task<TraktEpisode> SummaryAsync(string showId, int season, int episode, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktEpisodesSummaryRequest(Client) {
				Id = showId,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktShow show, TraktEpisode episode, int? page = null, int? limit = null) {
			return await CommentsAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault(), page, limit);
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string showId, int season, int episode, int? page = null, int? limit = null) {
			return await new TraktEpisodesCommentsRequest(Client) {
				Id = showId,
				Season = season,
				Episode = episode,
				Pagination = new PaginationOptions(page, limit)
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(TraktShow show, TraktEpisode episode) {
			return await RatingsAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault());
		}

		public async Task<TraktRatings> RatingsAsync(string showId, int season, int episode) {
			return await new TraktEpisodesRatingsRequest(Client) {
				Id = showId,
				Season = season,
				Episode = episode
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktShow show, TraktEpisode episode) {
			return await WatchingAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault());
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string showId, int season, int episode) {
			return await new TraktEpisodesWatchingRequest(Client) {
				Id = showId,
				Season = season,
				Episode = episode
			}.SendAsync();
		}

	}

}