using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Factories;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public class TraktSyncModule {

		public TraktSyncModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktSyncLastActivitiesResponse> LastActivitiesAsync() {
			return await new TraktSyncLastActivitiesRequest(Client).SendAsync();
		}

		public async Task<TraktSyncPlaybackResponse> PlaybackAsync() {
			return await new TraktSyncPlaybackRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncCollectionMoviesResponseItem>> CollectionMoviesAsync() {
			return await new TraktSyncCollectionMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncCollectionShowsResponseItem>> CollectionShowsAsync() {
			return await new TraktSyncCollectionShowsRequest(Client).SendAsync();
		}

		public async Task<TraktSyncAddResponse> CollectionAddAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies) {
			return await CollectionAddAsync(movies, null, null);
		}

		public async Task<TraktSyncAddResponse> CollectionAddAsync(IEnumerable<TraktShowWithCollectionMetadata> shows) {
			return await CollectionAddAsync(null, shows, null);
		}

		public async Task<TraktSyncAddResponse> CollectionAddAsync(IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await CollectionAddAsync(null, null, episodes);
		}

		public async Task<TraktSyncAddResponse> CollectionAddAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await CollectionAddAsync(
				TraktMovieFactory.FromIds<TraktMovieWithCollectionMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithCollectionMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithCollectionMetadata>(episodeIds));
		}

		public async Task<TraktSyncAddResponse> CollectionAddAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies, IEnumerable<TraktShowWithCollectionMetadata> shows, IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await new TraktSyncCollectionAddRequest(Client) {
				RequestBody = new TraktSyncCollectionAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

		public async Task<TraktSyncRemoveResponse> CollectionRemoveAsync(IEnumerable<TraktMovie> movies) {
			return await CollectionRemoveAsync(movies, null, null);
		}

		public async Task<TraktSyncRemoveResponse> CollectionRemoveAsync(IEnumerable<TraktShow> shows) {
			return await CollectionRemoveAsync(null, shows, null);
		}

		public async Task<TraktSyncRemoveResponse> CollectionRemoveAsync(IEnumerable<TraktEpisode> episodes) {
			return await CollectionRemoveAsync(null, null, episodes);
		}

		public async Task<TraktSyncRemoveResponse> CollectionRemoveAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await CollectionRemoveAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktSyncRemoveResponse> CollectionRemoveAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncCollectionRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchedMoviesResponseItem>> WatchedMoviesAsync() {
			return await new TraktSyncWatchedMoviesRequest(Client).SendAsync();
		}

		public async Task<IEnumerable<TraktSyncWatchedShowsResponseItem>> WatchedShowsAsync() {
			return await new TraktSyncWatchedShowsRequest(Client).SendAsync();
		}

		public async Task<TraktSyncAddResponse> WatchedAddAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies) {
			return await WatchedAddAsync(movies, null, null);
		}

		public async Task<TraktSyncAddResponse> WatchedAddAsync(IEnumerable<TraktShowWithWatchedMetadata> shows) {
			return await WatchedAddAsync(null, shows, null);
		}

		public async Task<TraktSyncAddResponse> WatchedAddAsync(IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await WatchedAddAsync(null, null, episodes);
		}

		public async Task<TraktSyncAddResponse> WatchedAddAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await WatchedAddAsync(
				TraktMovieFactory.FromIds<TraktMovieWithWatchedMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithWatchedMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithWatchedMetadata>(episodeIds));
		}

		public async Task<TraktSyncAddResponse> WatchedAddAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies, IEnumerable<TraktShowWithWatchedMetadata> shows, IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await new TraktSyncWatchedAddRequest(Client) {
				RequestBody = new TraktSyncWatchedAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

		public async Task<TraktSyncRemoveResponse> WatchedRemoveAsync(IEnumerable<TraktMovie> movies) {
			return await WatchedRemoveAsync(movies, null, null);
		}

		public async Task<TraktSyncRemoveResponse> WatchedRemoveAsync(IEnumerable<TraktShow> shows) {
			return await WatchedRemoveAsync(null, shows, null);
		}

		public async Task<TraktSyncRemoveResponse> WatchedRemoveAsync(IEnumerable<TraktEpisode> episodes) {
			return await WatchedRemoveAsync(null, null, episodes);
		}

		public async Task<TraktSyncRemoveResponse> WatchedRemoveAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await WatchedRemoveAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktSyncRemoveResponse> WatchedRemoveAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncWatchedRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsMoviesResponseItem>> RatingsMoviesAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsMoviesRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsShowsResponseItem>> RatingsShowsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsShowsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsSeasonsResponseItem>> RatingsSeasonsAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsSeasonsRequest(Client) { Rating = rating }.SendAsync();
		}

		public async Task<IEnumerable<TraktSyncRatingsEpisodesResponseItem>> RatingsEpisodesAsync(Rating rating = Rating.RatingUnspecified) {
			return await new TraktSyncRatingsEpisodesRequest(Client) { Rating = rating }.SendAsync();
		}

	}

}