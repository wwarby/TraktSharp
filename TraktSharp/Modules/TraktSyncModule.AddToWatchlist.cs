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

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) {
			return await AddToWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) {
			return await AddToWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) {
			return await AddToWatchlistAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByShowIdAsync(int showId, TraktNumericShowIdType showIdType) {
			return await AddToWatchlistAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) {
			return await AddToWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) {
			return await AddToWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(TraktMovie movie) {
			return await AddToWatchlistAsync(new List<TraktMovie> { movie }, null, null);
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(TraktShow show) {
			return await AddToWatchlistAsync(null, new List<TraktShow> { show }, null);
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(TraktEpisode episode) {
			return await AddToWatchlistAsync(null, null, new List<TraktEpisode> { episode });
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(IEnumerable<TraktMovie> movies) {
			return await AddToWatchlistAsync(movies, null, null);
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(IEnumerable<TraktShow> shows) {
			return await AddToWatchlistAsync(null, shows, null);
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(IEnumerable<TraktEpisode> episodes) {
			return await AddToWatchlistAsync(null, null, episodes);
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddToWatchlistAsync(
				TraktMovieFactory.FromIds<TraktMovie>(movieIds),
				TraktShowFactory.FromIds<TraktShow>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisode>(episodeIds));
		}

		/// <summary>Add one of more items to a user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToWatchlistAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) {
			return await SendAsync(new TraktSyncWatchlistAddRequest(Client) {
				RequestBody = new TraktSyncWatchlistAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}