using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Recommendations;

namespace TraktSharp.Modules {

	public class TraktRecommendationsModule {

		public TraktRecommendationsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<IEnumerable<TraktMovie>> GetRecommendedMoviesAsync() {
			return await new TraktRecommendationsMoviesRequest(Client).SendAsync();
		}

		public async Task DismissMovieRecommendationAsync(TraktMovie movie) {
			await DismissMovieRecommendationAsync(movie.Ids.GetBestId());
		}

		public async Task DismissMovieRecommendationAsync(string movieId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = movieId }.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> GetRecommendedShowsAsync() {
			return await new TraktRecommendationsShowsRequest(Client).SendAsync();
		}

		public async Task DismissShowRecommendationAsync(TraktShow show) {
			await DismissShowRecommendationAsync(show.Ids.GetBestId());
		}

		public async Task DismissShowRecommendationAsync(string showId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = showId }.SendAsync();
		}

	}

}