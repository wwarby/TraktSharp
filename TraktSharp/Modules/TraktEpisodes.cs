using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Episodes;

namespace TraktSharp.Modules {

	public class TraktEpisodes {

		public TraktEpisodes(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktEpisode> SummaryAsync(string id, int season, int episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktEpisodesSummaryRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string id, int season, int episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktEpisodesCommentsRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(string id, int season, int episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktEpisodesRatingsRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string id, int season, int episode, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktEpisodesWatchingRequest(Client) {
				Id = id,
				Season = season,
				Episode = episode,
				Extended = extended
			}.SendAsync();
		}

	}

}