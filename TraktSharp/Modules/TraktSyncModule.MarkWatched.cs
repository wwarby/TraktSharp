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

		/// <summary>Add a movie to the user's watched history by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(string movieId, TraktTextMovieIdType movieIdType = TraktTextMovieIdType.Auto) => await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, movieIdType));

		/// <summary>Add a movie to the user's watched history by ID</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByMovieIdAsync(int movieId, TraktNumericMovieIdType movieIdType) => await MarkWatchedAsync(TraktMovieFactory.FromId<TraktMovieWithWatchedMetadata>(movieId, movieIdType));

		/// <summary>Add a show to the user's watched history by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithWatchedMetadata { SeasonNumber = s }).ToList();
			}
			return await MarkWatchedAsync(obj);
		}

		/// <summary>Add a show to the user's watched history by ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <param name="seasonNumbers">If set, the action will be applied to the specified season numbers instead of the show itself</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByShowIdAsync(int showId, TraktNumericShowIdType showIdType, IEnumerable<int> seasonNumbers = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithWatchedMetadata>(showId, showIdType);
			if (seasonNumbers != null) {
				obj.Seasons = seasonNumbers.Select(s => new TraktSeasonWithWatchedMetadata { SeasonNumber = s }).ToList();
			}
			return await MarkWatchedAsync(obj);
		}

		/// <summary>Add an episode to the user's watched history by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(string episodeId, TraktTextEpisodeIdType episodeIdType = TraktTextEpisodeIdType.Auto) => await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, episodeIdType));

		/// <summary>Add an episode to the user's watched history by ID</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedByEpisodeIdAsync(int episodeId, TraktNumericEpisodeIdType episodeIdType) => await MarkWatchedAsync(TraktEpisodeFactory.FromId<TraktEpisodeWithWatchedMetadata>(episodeId, episodeIdType));

		/// <summary>Add a movie to the user's watched history</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktMovieWithWatchedMetadata movie) => await MarkWatchedAsync(new List<TraktMovieWithWatchedMetadata> { movie }, null, null);

		/// <summary>Add a show to the user's watched history</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktShowWithWatchedMetadata show) => await MarkWatchedAsync(null, new List<TraktShowWithWatchedMetadata> { show }, null);

		/// <summary>Add an episode to the user's watched history</summary>
		/// <param name="episode">The episode with optional metadata</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(TraktEpisodeWithWatchedMetadata episode) => await MarkWatchedAsync(null, null, new List<TraktEpisodeWithWatchedMetadata> { episode });

		/// <summary>Add one or more movies to the user's watched history</summary>
		/// <param name="movies">A collection of movies</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies) => await MarkWatchedAsync(movies, null, null);

		/// <summary>Add one or more shows to the user's watched history</summary>
		/// <param name="shows">A collection of shows</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktShowWithWatchedMetadata> shows) => await MarkWatchedAsync(null, shows, null);

		/// <summary>Add one or more episodes to the user's watched history</summary>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) => await MarkWatchedAsync(null, null, episodes);

		/// <summary>Add one or more items to the user's watched history by ID</summary>
		/// <param name="movieIds">A collection of movie IDs</param>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="episodeIds">A collection of episode IDs</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) =>
			await MarkWatchedAsync(
				TraktMovieFactory.FromIds<TraktMovieWithWatchedMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithWatchedMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithWatchedMetadata>(episodeIds));

		/// <summary>Add one or more items to the user's watched history</summary>
		/// <param name="movies">A collection of movies</param>
		/// <param name="shows">A collection of shows</param>
		/// <param name="episodes">A collection of episodes</param>
		/// <returns>See summary</returns>
		public async Task<TraktAddResponse> MarkWatchedAsync(IEnumerable<TraktMovieWithWatchedMetadata> movies, IEnumerable<TraktShowWithWatchedMetadata> shows, IEnumerable<TraktEpisodeWithWatchedMetadata> episodes) =>
			await SendAsync(new TraktSyncWatchedAddRequest(Client) {
				RequestBody = new TraktSyncWatchedAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});

	}

}