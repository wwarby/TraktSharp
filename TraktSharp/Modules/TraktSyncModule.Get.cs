using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

		public async Task<IEnumerable<TraktSyncCollectionMoviesResponseItem>> GetMoviesCollectionAsync() {
			return await new TraktSyncCollectionMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncCollectionShowsResponseItem>> GetShowsCollectionAsync() {
			return await new TraktSyncCollectionShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchedMoviesResponseItem>> GetWatchedMoviesAsync() {
			return await new TraktSyncWatchedMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchedShowsResponseItem>> GetWatchedShowsAsync() {
			return await new TraktSyncWatchedShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsMoviesResponseItem>> GetMovieRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsMoviesRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsShowsResponseItem>> GetShowRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsShowsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsSeasonsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsEpisodesRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync() {
			return await new TraktSyncWatchlistMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchlistShowsResponseItem>> GetWatchlistShowsAsync() {
			return await new TraktSyncWatchlistShowsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync() {
			return await new TraktSyncWatchlistSeasonsRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync() {
			return await new TraktSyncWatchlistEpisodesRequest(Client).SendAsync();
		}

	}

}