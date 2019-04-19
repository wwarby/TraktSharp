﻿using System.Collections.Generic;
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

		/// <summary>Remove a movie from the user's collection by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) => await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a movie from the user's collection by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) => await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a show from the user's collection by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason { SeasonNumber = s }).ToList();
			}
			return await RemoveFromCollectionAsync(obj);
		}

		/// <summary>Remove a show from the user's collection by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(int showId, TraktNumericShowIdType showIdType, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason { SeasonNumber = s }).ToList();
			}
			return await RemoveFromCollectionAsync(obj);
		}

		/// <summary>Remove an episode from the user's collection by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) => await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove an episode from the user's collection by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) => await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove a movie from the user's collection</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktMovie movie) => await RemoveFromCollectionAsync(new List<TraktMovie> { movie }, null, null);

		/// <summary>Remove a show from the user's collection</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktShow show) => await RemoveFromCollectionAsync(null, new List<TraktShow> { show }, null);

		/// <summary>Remove an episode from the user's collection</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktEpisode episode) => await RemoveFromCollectionAsync(null, null, new List<TraktEpisode> { episode });

		/// <summary>Remove one or more movies from the user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktMovie> movies) => await RemoveFromCollectionAsync(movies, null, null);

		/// <summary>Remove one or more shows from the user's collection</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktShow> shows) => await RemoveFromCollectionAsync(null, shows, null);

		/// <summary>Remove one or more episodes from the user's collection</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktEpisode> episodes) => await RemoveFromCollectionAsync(null, null, episodes);

		/// <summary>Remove one or more items from the user's collection by IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await RemoveFromCollectionAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));

		/// <summary>Remove one or more items from the user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) =>
			await SendAsync(new TraktSyncCollectionRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}