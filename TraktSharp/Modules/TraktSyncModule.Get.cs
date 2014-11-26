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

		public async Task<TraktSyncPlaybackResponse> GetPlaybackStateAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncPlaybackRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncCollectionMoviesRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncCollectionShowsRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchedMoviesResponseItem>> GetWatchedMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchedMoviesRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchedShowsResponseItem>> GetWatchedShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchedShowsRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsMoviesResponseItem>> GetMovieRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncRatingsMoviesRequest(Client) { Rating = rating, Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsShowsResponseItem>> GetShowRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncRatingsShowsRequest(Client) { Rating = rating, Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncRatingsSeasonsRequest(Client) { Rating = rating, Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncRatingsEpisodesRequest(Client) { Rating = rating, Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchlistMoviesRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistShowsResponseItem>> GetWatchlistShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchlistShowsRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchlistSeasonsRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task<IEnumerable<TraktWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktSyncWatchlistEpisodesRequest(Client) { Extended = extended }.SendAsync();
		}

	}

}