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

		public async Task<TraktSyncAddResponse> AddToWatchlistByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await AddToWatchlistAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await AddToWatchlistAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await AddToWatchlistAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistByShowIdAsync(int showId, IntShowIdType type) {
			return await AddToWatchlistAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await AddToWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await AddToWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(TraktMovie movie) {
			return await AddToWatchlistAsync(new List<TraktMovie> { movie }, null, null);
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(TraktShow show) {
			return await AddToWatchlistAsync(null, new List<TraktShow> { show }, null);
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(TraktEpisode episode) {
			return await AddToWatchlistAsync(null, null, new List<TraktEpisode> { episode });
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(IEnumerable<TraktMovie> movies) {
			return await AddToWatchlistAsync(movies, null, null);
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(IEnumerable<TraktShow> shows) {
			return await AddToWatchlistAsync(null, shows, null);
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(IEnumerable<TraktEpisode> episodes) {
			return await AddToWatchlistAsync(null, null, episodes);
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddToWatchlistAsync(
				TraktMovieFactory.FromIds<TraktMovie>(movieIds),
				TraktShowFactory.FromIds<TraktShow>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisode>(episodeIds));
		}

		public async Task<TraktSyncAddResponse> AddToWatchlistAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await new TraktSyncWatchlistAddRequest(Client) {
				RequestBody = new TraktSyncWatchlistAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			}.SendAsync();
		}

	}

}