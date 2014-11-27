using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Request.Recommendations;

namespace TraktSharp.Modules {

	public class TraktRecommendationsModule : TraktModuleBase {

		public TraktRecommendationsModule(TraktClient client) : base(client) { }

		public async Task<IEnumerable<TraktMovie>> GetRecommendedMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktRecommendationsMoviesRequest(Client) { Extended = extended });
		}

		public async Task DismissMovieRecommendationAsync(TraktMovie movie) {
			await DismissMovieRecommendationAsync(movie.Ids.GetBestId());
		}

		public async Task DismissMovieRecommendationAsync(string movieId) {
			await SendAsync(new TraktRecommendationsShowsDismissRequest(Client) { Id = movieId });
		}

		public async Task<IEnumerable<TraktShow>> GetRecommendedShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktRecommendationsShowsRequest(Client) { Extended = extended });
		}

		public async Task DismissShowRecommendationAsync(TraktShow show) {
			await DismissShowRecommendationAsync(show.Ids.GetBestId());
		}

		public async Task DismissShowRecommendationAsync(string showId) {
			await SendAsync(new TraktRecommendationsShowsDismissRequest(Client) { Id = showId });
		}

	}

}