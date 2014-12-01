using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;
using TraktSharp.Enums;
using TraktSharp.Factories;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule {

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) {
			return await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) {
			return await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) {
			return await RemoveRatingAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByShowIdAsync(int showId, TraktNumericShowIdType showIdType) {
			return await RemoveRatingAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) {
			return await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) {
			return await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktMovie movie) {
			return await RemoveRatingsAsync(new List<TraktMovie> { movie }, null, null);
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktShow show) {
			return await RemoveRatingsAsync(null, new List<TraktShow> { show }, null);
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktEpisode episode) {
			return await RemoveRatingsAsync(null, null, new List<TraktEpisode> { episode });
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveRatingsAsync(movies, null, null);
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktShow> shows) {
			return await RemoveRatingsAsync(null, shows, null);
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveRatingsAsync(null, null, episodes);
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveRatingsAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await SendAsync(new TraktSyncRatingsRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}