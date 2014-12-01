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

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(string movieId, StringMovieIdType movieIdType = StringMovieIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByMovieIdAsync(int movieId, IntMovieIdType movieIdType) {
			return await RemoveFromCollectionAsync(TraktMovieFactory.FromId(movieId, movieIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(string showId, StringShowIdType showIdType = StringShowIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByShowIdAsync(int showId, IntShowIdType showIdType) {
			return await RemoveFromCollectionAsync(TraktShowFactory.FromId(showId, showIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(string episodeId, StringEpisodeIdType episodeIdType = StringEpisodeIdType.Auto) {
			return await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionByEpisodeIdAsync(int episodeId, IntEpisodeIdType episodeIdType) {
			return await RemoveFromCollectionAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktMovie movie) {
			return await RemoveFromCollectionAsync(new List<TraktMovie> { movie }, null, null);
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktShow show) {
			return await RemoveFromCollectionAsync(null, new List<TraktShow> { show }, null);
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(TraktEpisode episode) {
			return await RemoveFromCollectionAsync(null, null, new List<TraktEpisode> { episode });
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktMovie> movies) {
			return await RemoveFromCollectionAsync(movies, null, null);
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktShow> shows) {
			return await RemoveFromCollectionAsync(null, shows, null);
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<TraktEpisode> episodes) {
			return await RemoveFromCollectionAsync(null, null, episodes);
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveFromCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await RemoveFromCollectionAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));
		}

		/// <summary>Remove one or more items from a user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
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