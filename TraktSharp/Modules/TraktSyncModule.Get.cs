using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule {

		public TraktSyncModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktSyncLastActivitiesResponse> GetLastActivitiesAsync() {
			return await new TraktSyncLastActivitiesRequest(Client).SendAsync();
		}

		public async Task<TraktSyncPlaybackResponse> GetPlaybackStateAsync() {
			return await new TraktSyncPlaybackRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync() {
			return await new TraktSyncCollectionMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync() {
			return await new TraktSyncCollectionShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktWatchedMoviesResponseItem>> GetWatchedMoviesAsync() {
			return await new TraktSyncWatchedMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktWatchedShowsResponseItem>> GetWatchedShowsAsync() {
			return await new TraktSyncWatchedShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsMoviesResponseItem>> GetMovieRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsMoviesRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsShowsResponseItem>> GetShowRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsShowsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsSeasonsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsEpisodesRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync() {
			return await new TraktSyncWatchlistMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistShowsResponseItem>> GetWatchlistShowsAsync() {
			return await new TraktSyncWatchlistShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync() {
			return await new TraktSyncWatchlistSeasonsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync() {
			return await new TraktSyncWatchlistEpisodesRequest(Client).SendAsync();
		}

	}

}