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

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) {
			return await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByShowIdAsync(int showId, TraktNumericShowIdType showIdType) {
			return await RemoveFromWatchlistAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) {
			return await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) {
			return await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktMovie movie) {
			return await RemoveFromWatchlistAsync(new List<TraktMovie> { movie }, null, null);
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktShow show) {
			return await RemoveFromWatchlistAsync(null, new List<TraktShow> { show }, null);
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktEpisode episode) {
			return await RemoveFromWatchlistAsync(null, null, new List<TraktEpisode> { episode });
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveFromWatchlistAsync(movies, null, null);
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktShow> shows) {
			return await RemoveFromWatchlistAsync(null, shows, null);
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveFromWatchlistAsync(null, null, episodes);
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveFromWatchlistAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		/// <summary>Remove one or more items from a user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await SendAsync(new TraktSyncWatchlistRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}