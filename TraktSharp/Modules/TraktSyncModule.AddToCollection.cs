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

		/// <summary>Add a movie to the user's collection by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) => await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, movieIdType));

		/// <summary>Add a movie to the user's collection by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) => await AddToCollectionAsync(TraktMovieFactory.FromId<TraktMovieWithCollectionMetadata>(movieId, movieIdType));

		/// <summary>Add a show to the user's collection by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithCollectionMetadata { SeasonNumber = s }).ToList();
			}
			return await AddToCollectionAsync(obj);
		}

		/// <summary>Add a show to the user's collection by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByShowIdAsync(int showId, TraktNumericShowIdType showIdType, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithCollectionMetadata>(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithCollectionMetadata { SeasonNumber = s }).ToList();
			}
			return await AddToCollectionAsync(obj);
		}

		/// <summary>Add an episode to the user's collection by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType showIdType = TraktTextEpisodeIdType.Auto) => await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, showIdType));

		/// <summary>Add an episode to the user's collection by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType showIdType) => await AddToCollectionAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithCollectionMetadata>(episodeId, showIdType));

		/// <summary>Add a movie to the user's collection</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktMovieWithCollectionMetadata movie) => await AddToCollectionAsync(new List<TraktMovieWithCollectionMetadata> { movie }, null, null);

		/// <summary>Add a show to the user's collection</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktShowWithCollectionMetadata show) => await AddToCollectionAsync(null, new List<TraktShowWithCollectionMetadata> { show }, null);

		/// <summary>Add an episode to the user's collection</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(TraktEpisodeWithCollectionMetadata episode) => await AddToCollectionAsync(null, null, new List<TraktEpisodeWithCollectionMetadata> { episode });

		/// <summary>Add one or more movies to the user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies) => await AddToCollectionAsync(movies, null, null);

		/// <summary>Add one or more shows to the user's collection</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktShowWithCollectionMetadata> shows) => await AddToCollectionAsync(null, shows, null);

		/// <summary>Add one or more episodes to the user's collection</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) => await AddToCollectionAsync(null, null, episodes);

		/// <summary>Add items to the user's collection by IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await AddToCollectionAsync(
				TraktMovieFactory.FromIds<TraktMovieWithCollectionMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithCollectionMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithCollectionMetadata>(episodeIds));

		/// <summary>Add items to the user's collection</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddToCollectionAsync(IEnumerable<TraktMovieWithCollectionMetadata> movies, IEnumerable<TraktShowWithCollectionMetadata> shows, IEnumerable<TraktEpisodeWithCollectionMetadata> episodes) =>
			await SendAsync(new TraktSyncCollectionAddRequest(Client) {
				RequestBody = new TraktSyncCollectionAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}