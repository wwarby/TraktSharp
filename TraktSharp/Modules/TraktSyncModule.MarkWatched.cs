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

		public async Task<TraktSyncAddResponse> MarkWatchedByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedByShowIdAsync(int showId, IntShowIdType type) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(TraktMovieWithWatchedMetadata movie) {
			return await MarkWatchedAsync(new List<TraktMovieWithWatchedMetadata> { movie }, null, null);
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(TraktShowWithWatchedMetadata show) {
			return await MarkWatchedAsync(null, new List<TraktShowWithWatchedMetadata> { show }, null);
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(TraktEpisodeWithWatchedMetadata episode) {
			return await MarkWatchedAsync(null, null, new List<TraktEpisodeWithWatchedMetadata> { episode });
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies) {
			return await MarkWatchedAsync(movies, null, null);
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(IEnumerable<TraktShowWithWatchedMetadata> shows) {
			return await MarkWatchedAsync(null, shows, null);
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await MarkWatchedAsync(null, null, episodes);
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await MarkWatchedAsync(
				TraktMovieFactory.FromIds<TraktMovieWithWatchedMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithWatchedMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithWatchedMetadata>(episodeIds));
		}

		public async Task<TraktSyncAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies, IEnumerable<TraktShowWithWatchedMetadata> shows, IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await new TraktSyncWatchedAddRequest(Client) {
				RequestBody = new TraktSyncWatchedAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}