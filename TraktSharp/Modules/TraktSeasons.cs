using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Request.Seasons;
using TraktSharp.Response;

namespace TraktSharp.Modules {

	public class TraktSeasons {

		public TraktSeasons(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktSeason> SummaryAsync(string id, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsSummaryRequest(Client) {
				Id = id,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktEpisode>> SeasonAsync(string id, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsSeasonRequest(Client) {
				Id = id,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktComment>> CommentsAsync(string id, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsCommentsRequest(Client) {
				Id = id,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktRatings> RatingsAsync(string id, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsRatingsRequest(Client) {
				Id = id,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktUser>> WatchingAsync(string id, int season, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktSeasonsWatchingRequest(Client) {
				Id = id,
				Season = season,
				Extended = extended
			}.SendAsync();
		}

	}

}