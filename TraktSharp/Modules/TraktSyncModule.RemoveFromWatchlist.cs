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

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByShowIdAsync(int showId, IntShowIdType type) {
			return await RemoveFromWatchlistAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(TraktMovie movie) {
			return await RemoveFromWatchlistAsync(new List<TraktMovie> { movie }, null, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(TraktShow show) {
			return await RemoveFromWatchlistAsync(null, new List<TraktShow> { show }, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(TraktEpisode episode) {
			return await RemoveFromWatchlistAsync(null, null, new List<TraktEpisode> { episode });
		}


		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveFromWatchlistAsync(movies, null, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktShow> shows) {
			return await RemoveFromWatchlistAsync(null, shows, null);
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveFromWatchlistAsync(null, null, episodes);
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveFromWatchlistAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktSyncRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncWatchlistRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}