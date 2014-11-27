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

		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(string movieId, StringMovieIdType type = StringMovieIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(int movieId, IntMovieIdType type) {
			return await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(string showId, StringShowIdType type = StringShowIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(int showId, IntShowIdType type) {
			return await RemoveFromCollectionAsync(TraktShowFactory.FromId(showId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(string episodeId, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(int episodeId, IntEpisodeIdType type) {
			return await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, type));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktMovie movie) {
			return await RemoveFromCollectionAsync(new List<TraktMovie> { movie }, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktShow show) {
			return await RemoveFromCollectionAsync(null, new List<TraktShow> { show }, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktEpisode episode) {
			return await RemoveFromCollectionAsync(null, null, new List<TraktEpisode> { episode });
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveFromCollectionAsync(movies, null, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktShow> shows) {
			return await RemoveFromCollectionAsync(null, shows, null);
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveFromCollectionAsync(null, null, episodes);
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveFromCollectionAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await SendAsync(new TraktSyncCollectionRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}