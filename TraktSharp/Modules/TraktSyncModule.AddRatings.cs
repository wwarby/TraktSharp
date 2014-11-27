using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;
using TraktSharp.Factories;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule {

		public async Task<TraktAddResponse> AddRatingsByMovieIdAsync(string movieId, StringMovieIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsByMovieIdAsync(int movieId, IntMovieIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktMovieFactory.FromId<TraktMovieWithRatingsMetadata>(movieId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsByShowIdAsync(string showId, StringShowIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsByShowIdAsync(int showId, IntShowIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktShowFactory.FromId<TraktShowWithRatingsMetadata>(showId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsByEpisodeIdAsync(string episodeId, StringEpisodeIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsByEpisodeIdAsync(int episodeId, IntEpisodeIdType type, Rating rating, DateTime? ratedAt = null) {
			var obj = TraktEpisodeFactory.FromId<TraktEpisodeWithRatingsMetadata>(episodeId, type);
			obj.Rating = rating;
			obj.RatedAt = ratedAt;
			return await AddRatingsAsync(obj);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(TraktMovieWithRatingsMetadata movie) {
			return await AddRatingsAsync(new List<TraktMovieWithRatingsMetadata> { movie }, null, null);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(TraktShowWithRatingsMetadata show) {
			return await AddRatingsAsync(null, new List<TraktShowWithRatingsMetadata> { show }, null);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(TraktEpisodeWithRatingsMetadata episode) {
			return await AddRatingsAsync(null, null, new List<TraktEpisodeWithRatingsMetadata> { episode });
		}
		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies) {
			return await AddRatingsAsync(movies, null, null);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktShowWithRatingsMetadata> shows) {
			return await AddRatingsAsync(null, shows, null);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) {
			return await AddRatingsAsync(null, null, episodes);
		}

		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<string> movieIds, IEnumerable<string> showIds, IEnumerable<string> episodeIds) {
			return await AddRatingsAsync(
				TraktMovieFactory.FromIds<TraktMovieWithRatingsMetadata>(movieIds),
				TraktShowFactory.FromIds<TraktShowWithRatingsMetadata>(showIds),
				TraktEpisodeFactory.FromIds<TraktEpisodeWithRatingsMetadata>(episodeIds));
		}

		public async Task<TraktAddResponse> AddRatingsAsync(IEnumerable<TraktMovieWithRatingsMetadata> movies, IEnumerable<TraktShowWithRatingsMetadata> shows, IEnumerable<TraktEpisodeWithRatingsMetadata> episodes) {
			return await SendAsync(new TraktSyncRatingsAddRequest(Client) {
				RequestBody = new TraktSyncRatingsAddRequestBody {
					Movies = movies,
					Shows = shows,
					Episodes = episodes
				}
			});
		}

	}

}