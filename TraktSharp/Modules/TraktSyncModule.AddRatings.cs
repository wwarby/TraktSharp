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

	public partial class TraktSyncModule : TraktModuleBase {

		/// <summary>Rate a movie by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType, TraktRating rating, DateTimeOffset? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, movieIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate a movie by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType, TraktRating rating, DateTimeOffset? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, movieIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate a show by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <param name="seasonNumbers">
		///     If set, the action will be applied to the specified season numbers instead of the show
		///     itself
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByShowIdAsync(string showId, TraktTextShowIdType showIdType, TraktRating rating, DateTimeOffset? ratedAt = null, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, showIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithRatingsMetadata {SeasonNumber = s}).ToList();
			}

			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate a show by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <param name="seasonNumbers">
		///     If set, the action will be applied to the specified season numbers instead of the show
		///     itself
		/// </param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByShowIdAsync(int showId, TraktNumericShowIdType showIdType, TraktRating rating, DateTimeOffset? ratedAt = null, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, showIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithRatingsMetadata {SeasonNumber = s}).ToList();
			}

			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate an episode by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType, TraktRating rating, DateTimeOffset? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, episodeIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate an episode by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="rating">The rating</param>
		/// <param name="ratedAt">The UTC date when the rating was made</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType, TraktRating rating, DateTimeOffset? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, episodeIdType);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		/// <summary>Rate a movie</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktMovieWithRatingsMetadata movie) => await AddRatingsAsync(new List<TraktMovieWithRatingsMetadata> {movie}, null, null);

		/// <summary>Rate a show</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktShowWithRatingsMetadata show) => await AddRatingsAsync(null, new List<TraktShowWithRatingsMetadata> {show}, null);

		/// <summary>Rate an episode</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(TraktEpisodeWithRatingsMetadata episode) => await AddRatingsAsync(null, null, new List<TraktEpisodeWithRatingsMetadata> {episode});

		/// <summary>Rate one or more movies</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies) => await AddRatingsAsync(movies, null, null);

		/// <summary>Rate one or more shows</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktShowWithRatingsMetadata> shows) => await AddRatingsAsync(null, shows, null);

		/// <summary>Rate one or more episodes</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) => await AddRatingsAsync(null, null, episodes);

		/// <summary>Rate one or more items</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await AddRatingsAsync(
				TraktMovieFactory.FromIds<TraktMovieWithRatingsMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithRatingsMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithRatingsMetadata>(episodeIds));

		/// <summary>Rate one or more items</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies, IEnumerable<TraktShowWithRatingsMetadata> shows, IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) =>
			await SendAsync(new TraktSyncRatingsAddRequest(Client) {
				RequestBody = new TraktSyncRatingsAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}