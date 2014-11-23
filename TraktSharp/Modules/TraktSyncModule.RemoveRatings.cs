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

		public async Task<TraktSyncRemoveResponse> RemoveRatingByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await RemoveRatingAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingByShowIdAsync(int showId, IntShowIdType type) {
			return await RemoveRatingAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingAsync(TraktMovie movie) {
			return await RemoveRatingsAsync(new List<TraktMovie> { movie }, null, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingAsync(TraktShow show) {
			return await RemoveRatingsAsync(null, new List<TraktShow> { show }, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingAsync(TraktEpisode episode) {
			return await RemoveRatingsAsync(null, null, new List<TraktEpisode> { episode });
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveRatingsAsync(movies, null, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktShow> shows) {
			return await RemoveRatingsAsync(null, shows, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveRatingsAsync(null, null, episodes);
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveRatingsAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktSyncRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncRatingsRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}