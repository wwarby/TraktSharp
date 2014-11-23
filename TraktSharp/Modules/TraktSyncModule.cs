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
				RequestBody = new TraktSyncCollectionRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}