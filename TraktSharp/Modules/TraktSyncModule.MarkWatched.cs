using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;
using TraktSharp.Factories;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule {

		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(int showId, IntShowIdType type) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, type));
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(TraktMovieWithWatchedMetadata movie) {
			return await MarkWatchedAsync(new List<TraktMovieWithWatchedMetadata> { movie }, null, null);
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(TraktShowWithWatchedMetadata show) {
			return await MarkWatchedAsync(null, new List<TraktShowWithWatchedMetadata> { show }, null);
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(TraktEpisodeWithWatchedMetadata episode) {
			return await MarkWatchedAsync(null, null, new List<TraktEpisodeWithWatchedMetadata> { episode });
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies) {
			return await MarkWatchedAsync(movies, null, null);
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktShowWithWatchedMetadata> shows) {
			return await MarkWatchedAsync(null, shows, null);
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await MarkWatchedAsync(null, null, episodes);
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await MarkWatchedAsync(
				TraktMovieFactory.FromIds<TraktMovieWithWatchedMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithWatchedMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithWatchedMetadata>(episodeIds));
		}

		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies, IEnumerable<TraktShowWithWatchedMetadata> shows, IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
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