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

		/// <summary>Remove a rating for a movie by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) => await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a rating for a movie by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) => await RemoveRatingAsync(TraktMovieFactory.FromId(movieId, movieIdType));

		/// <summary>Remove a rating for a show by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">
		///     If set, the action will be applied to the specified season numbers instead of the show
		///     itself
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason {SeasonNumber = s}).ToList();
			}

			return await RemoveRatingAsync(obj);
		}

		/// <summary>Remove a rating for a show by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">
		///     If set, the action will be applied to the specified season numbers instead of the show
		///     itself
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByShowIdAsync(int showId, TraktNumericShowIdType showIdType, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeason {SeasonNumber = s}).ToList();
			}

			return await RemoveRatingAsync(obj);
		}

		/// <summary>Remove a rating for an episode by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) => await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove a rating for an episode by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) => await RemoveRatingAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType));

		/// <summary>Remove a rating for a movie</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktMovie movie) => await RemoveRatingsAsync(new List<TraktMovie> {movie}, null, null);

		/// <summary>Remove a rating for a show</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktShow show) => await RemoveRatingsAsync(null, new List<TraktShow> {show}, null);

		/// <summary>Remove a rating for a an episode</summary>
		/// <param name="episode">The episode</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingAsync(TraktEpisode episode) => await RemoveRatingsAsync(null, null, new List<TraktEpisode> {episode});

		/// <summary>Remove ratings for one or more movies</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies) => await RemoveRatingsAsync(movies, null, null);

		/// <summary>Remove ratings for one or more shows</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktShow> shows) => await RemoveRatingsAsync(null, shows, null);

		/// <summary>Remove ratings for one or more episodes</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktEpisode> episodes) => await RemoveRatingsAsync(null, null, episodes);

		/// <summary>Remove ratings for one or more items by IDs</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await RemoveRatingsAsync(
				TraktMovieFactory.FromIds(movieIds),
				TraktShowFactory.FromIds(showIds),
				TraktEpisodeFactory.FromIds(episodeIds));

		/// <summary>Remove ratings for one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktRemoveResponse> RemoveRatingsAsync(IEnumerable<TraktMovie> movies, IEnumerable<TraktShow> shows, IEnumerable<TraktEpisode> episodes) =>
			await SendAsync(new TraktSyncRatingsRemoveRequest(Client) {
				RequestBody = new TraktSyncRemoveRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}