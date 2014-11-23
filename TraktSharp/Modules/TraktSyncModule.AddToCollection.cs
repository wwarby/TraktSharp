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

	public partial class TraktSyncModule {

		public async Task<TraktSyncAddResponse> AddToCollectionByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await AddToCollectionAsync(TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionByShowIdAsync(int showId, IntShowIdType type) {
			return await AddToCollectionAsync(TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(TraktMovieWithCollectionMetadata movie) {
			return await AddToCollectionAsync(new List<TraktMovieWithCollectionMetadata> { movie }, null, null);
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(TraktShowWithCollectionMetadata show) {
			return await AddToCollectionAsync(null, new List<TraktShowWithCollectionMetadata> { show }, null);
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(TraktEpisodeWithCollectionMetadata episode) {
			return await AddToCollectionAsync(null, null, new List<TraktEpisodeWithCollectionMetadata> { episode });
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies) {
			return await AddToCollectionAsync(movies, null, null);
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(IEnumerable<TraktShowWithCollectionMetadata> shows) {
			return await AddToCollectionAsync(null, shows, null);
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await AddToCollectionAsync(null, null, episodes);
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddToCollectionAsync(
				TraktMovieFactory.FromIds<TraktMovieWithCollectionMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithCollectionMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithCollectionMetadata>(episodeIds));
		}

		public async Task<TraktSyncAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies, IEnumerable<TraktShowWithCollectionMetadata> shows, IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await new TraktSyncCollectionAddRequest(Client) {
				RequestBody = new TraktSyncCollectionAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}