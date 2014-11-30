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

		/// <summary>Add items to a watch history</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, movieIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(int movieId, IntMovieIdType movieIdType) {
			return await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, movieIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(string showId, StringShowIdType showIdType = StringShowIdType.Auto) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, showIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(int showId, IntShowIdType showIdType) {
			return await MarkWatchedAsync(TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, showIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, episodeIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(int episodeId, IntEpisodeIdType episodeIdType) {
			return await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, episodeIdType));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktMovieWithWatchedMetadata movie) {
			return await MarkWatchedAsync(new List<TraktMovieWithWatchedMetadata> { movie }, null, null);
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktShowWithWatchedMetadata show) {
			return await MarkWatchedAsync(null, new List<TraktShowWithWatchedMetadata> { show }, null);
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktEpisodeWithWatchedMetadata episode) {
			return await MarkWatchedAsync(null, null, new List<TraktEpisodeWithWatchedMetadata> { episode });
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies) {
			return await MarkWatchedAsync(movies, null, null);
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktShowWithWatchedMetadata> shows) {
			return await MarkWatchedAsync(null, shows, null);
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await MarkWatchedAsync(null, null, episodes);
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await MarkWatchedAsync(
				TraktMovieFactory.FromIds<TraktMovieWithWatchedMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithWatchedMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithWatchedMetadata>(episodeIds));
		}

		/// <summary>Add items to a watch history</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies, IEnumerable<TraktShowWithWatchedMetadata> shows, IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) {
			return await SendAsync(new TraktSyncWatchedAddRequest(Client) {
				RequestBody = new TraktSyncWatchedAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}