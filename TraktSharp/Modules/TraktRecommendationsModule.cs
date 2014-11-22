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

		public async Task<IEnumerable<TraktMovie>> MoviesAsync() {
			return await new TraktRecommendationsMoviesRequest(Client).SendAsync();
		}

		public async Task DismissMovieAsync(TraktMovie movie) {
			await DismissMovieAsync(movie.Ids.GetBestId());
		}

		public async Task DismissMovieAsync(string movieId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = movieId }.SendAsync();
		}

		public async Task<IEnumerable<TraktShow>> ShowsAsync() {
			return await new TraktRecommendationsShowsRequest(Client).SendAsync();
		}

		public async Task DismissShowAsync(TraktShow show) {
			await DismissShowAsync(show.Ids.GetBestId());
		}

		public async Task DismissShowAsync(string showId) {
			await new TraktRecommendationsShowsDismissRequest(Client) { Id = showId }.SendAsync();
		}

	}

}