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

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) {
			return await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, movieIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) {
			return await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, movieIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) {
			return await AddToCollectionAsync(TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, showIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByShowIdAsync(int showId, TraktNumericShowIdType showIdType) {
			return await AddToCollectionAsync(TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, showIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType showIdType = TraktTextEpisodeIdType.Auto) {
			return await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, showIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType showIdType) {
			return await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, showIdType));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktMovieWithCollectionMetadata movie) {
			return await AddToCollectionAsync(new List<TraktMovieWithCollectionMetadata> { movie }, null, null);
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktShowWithCollectionMetadata show) {
			return await AddToCollectionAsync(null, new List<TraktShowWithCollectionMetadata> { show }, null);
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktEpisodeWithCollectionMetadata episode) {
			return await AddToCollectionAsync(null, null, new List<TraktEpisodeWithCollectionMetadata> { episode });
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies) {
			return await AddToCollectionAsync(movies, null, null);
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktShowWithCollectionMetadata> shows) {
			return await AddToCollectionAsync(null, shows, null);
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await AddToCollectionAsync(null, null, episodes);
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddToCollectionAsync(
				TraktMovieFactory.FromIds<TraktMovieWithCollectionMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithCollectionMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithCollectionMetadata>(episodeIds));
		}

		/// <summary>Add items to a user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies, IEnumerable<TraktShowWithCollectionMetadata> shows, IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) {
			return await SendAsync(new TraktSyncCollectionAddRequest(Client) {
				RequestBody = new TraktSyncCollectionAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}