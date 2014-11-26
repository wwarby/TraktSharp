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

		public async Task<IEnumerable<TraktMovie>> GetRecommendedMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktRecommendationsMoviesRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task DismissMovieRecommendationAsync(TraktMovie movie) {
			await DismissMovieRecommendationAsync(movie.Ids.GetBestId());
		}

		public async Task DismissMovieRecommendationAsync(string movieId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = movieId }.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> GetRecommendedShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktRecommendationsShowsRequest(Client) { Extended = extended }.SendAsync();
		}

		public async Task DismissShowRecommendationAsync(TraktShow show) {
			await DismissShowRecommendationAsync(show.Ids.GetBestId());
		}

		public async Task DismissShowRecommendationAsync(string showId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = showId }.SendAsync();
		}

	}

}