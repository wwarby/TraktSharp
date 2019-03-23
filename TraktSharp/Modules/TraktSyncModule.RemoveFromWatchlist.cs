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

		/// <summary>Remove a movie from the user's watchlist by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) => await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a movie from the user's watchlist by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) => await RemoveFromWatchlistAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a show from the user's watchlist by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason { SeasonNumber = s }).ToList();
			}
			return await RemoveFromWatchlistAsync(obj);
		}

		/// <summary>Remove a show from the user's watchlist by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByShowIdAsync(int showId, TraktNumericShowIdType showIdType, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason { SeasonNumber = s }).ToList();
			}
			return await RemoveFromWatchlistAsync(obj);
		}

		/// <summary>Remove an episode from the user's watchlist by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) => await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove an episode from the user's watchlist by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) => await RemoveFromWatchlistAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove a movie from the user's watchlist</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktMovie movie) => await RemoveFromWatchlistAsync(new List<TraktMovie> { movie }, null, null);

		/// <summary>Remove a show from the user's watchlist</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktShow show) => await RemoveFromWatchlistAsync(null, new List<TraktShow> { show }, null);

		/// <summary>Remove an episode from the user's watchlist</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(TraktEpisode episode) => await RemoveFromWatchlistAsync(null, null, new List<TraktEpisode> { episode });

		/// <summary>Remove one or more movies from the user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies) => await RemoveFromWatchlistAsync(movies, null, null);

		/// <summary>Remove one or more shows from the user's watchlist</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktShow> shows) => await RemoveFromWatchlistAsync(null, shows, null);

		/// <summary>Remove one or more episodes from the user's watchlist</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktEpisode> episodes) => await RemoveFromWatchlistAsync(null, null, episodes);

		/// <summary>Remove one or more items from the user's watchlist by IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await RemoveFromWatchlistAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));

		/// <summary>Remove one or more items from the user's watchlist</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromWatchlistAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) =>
			await SendAsync(new TraktSyncWatchlistRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}