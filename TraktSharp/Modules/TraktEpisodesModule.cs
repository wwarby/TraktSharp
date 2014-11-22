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

		public async Task<TraktEpisode> SummaryAsync(TraktShow show, TraktEpisode episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await SummaryAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault(), extended);
		}

		public async Task<TraktEpisode> SummaryAsync(string showId, int season, int episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktEpisodesSummaryRequest(Client) {
				Id = showId,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(TraktShow show, TraktEpisode episode) {
			return await CommentsAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault());
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string id, int season, int episode) {
			return await new TraktEpisodesCommentsRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(TraktShow show, TraktEpisode episode) {
			return await RatingsAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault());
		}

		public async Task<TraktRatings> RatingsAsync(string id, int season, int episode) {
			return await new TraktEpisodesRatingsRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(TraktShow show, TraktEpisode episode) {
			return await WatchingAsync(show.Ids.GetBestId(), episode.Season.GetValueOrDefault(), episode.Number.GetValueOrDefault());
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string id, int season, int episode) {
			return await new TraktEpisodesWatchingRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode
			}.SendAsync();
		}

	}

}