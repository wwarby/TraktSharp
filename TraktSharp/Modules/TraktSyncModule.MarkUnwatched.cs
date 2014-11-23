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

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await MarkUnwatchedAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await MarkUnwatchedAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await MarkUnwatchedAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByShowIdAsync(int showId, IntShowIdType type) {
			return await MarkUnwatchedAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await MarkUnwatchedAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await MarkUnwatchedAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(TraktMovie movie) {
			return await MarkUnwatchedAsync(new List<TraktMovie> { movie }, null, null);
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(TraktShow show) {
			return await MarkUnwatchedAsync(null, new List<TraktShow> { show }, null);
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(TraktEpisode episode) {
			return await MarkUnwatchedAsync(null, null, new List<TraktEpisode> { episode });
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktMovie> movies) {
			return await MarkUnwatchedAsync(movies, null, null);
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktShow> shows) {
			return await MarkUnwatchedAsync(null, shows, null);
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktEpisode> episodes) {
			return await MarkUnwatchedAsync(null, null, episodes);
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await MarkUnwatchedAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktSyncRemoveResponse> MarkUnwatchedAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncWatchedRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}