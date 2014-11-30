using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Recommendations;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Recommendations namespace</summary>
	public class TraktRecommendationsModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktRecommendationsModule(TraktClient client) : base(client) { }

		/// <summary>Personalized movie recommendations for a user. Results returned with the top recommendation first.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktMovie>> GetRecommendedMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktRecommendationsMoviesRequest(Client) { Extended = extended });
		}

		/// <summary>Dismiss a movie from getting recommended anymore</summary>
		/// <param name="movie">The movie</param>
		/// <returns>See summary</returns>
		public async Task DismissMovieRecommendationAsync(TraktMovie movie) {
			await DismissMovieRecommendationAsync(movie.Ids.GetBestId());
		}

		/// <summary>Dismiss a movie from getting recommended anymore</summary>
		/// <param name="movieId">The movie ID</param>
		/// <returns>See summary</returns>
		public async Task DismissMovieRecommendationAsync(string movieId) {
			await SendAsync(new TraktRecommendationsShowsDismissRequest(Client) { Id = movieId });
		}

		/// <summary>Personalized show recommendations for a user. Results returned with the top recommendation first.</summary>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<IEnumerable<TraktShow>> GetRecommendedShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktRecommendationsShowsRequest(Client) { Extended = extended });
		}

		/// <summary>Dismiss a show from getting recommended anymore</summary>
		/// <param name="show">The show</param>
		/// <returns>See summary</returns>
		public async Task DismissShowRecommendationAsync(TraktShow show) {
			await DismissShowRecommendationAsync(show.Ids.GetBestId());
		}

		/// <summary>Dismiss a show from getting recommended anymore</summary>
		/// <param name="showId">The show ID</param>
		/// <returns>See summary</returns>
		public async Task DismissShowRecommendationAsync(string showId) {
			await SendAsync(new TraktRecommendationsShowsDismissRequest(Client) { Id = showId });
		}

	}

}