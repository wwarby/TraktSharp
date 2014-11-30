using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response;
using TraktSharp.Entities.Response.Sync;
using TraktSharp.Request.Sync;

namespace TraktSharp.Modules {

	public partial class TraktSyncModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktSyncModule(TraktClient client) : base(client) { }

		public async Task<TraktSyncLastActivitiesResponse> GetLastActivitiesAsync() {
			return await SendAsync(new TraktSyncLastActivitiesRequest(Client));
		}

		public async Task<TraktSyncPlaybackResponse> GetPlaybackStateAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncPlaybackRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktCollectionMoviesResponseItem>> GetMoviesCollectionAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncCollectionMoviesRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktCollectionShowsResponseItem>> GetShowsCollectionAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncCollectionShowsRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchedMoviesResponseItem>> GetWatchedMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchedMoviesRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchedShowsResponseItem>> GetWatchedShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchedShowsRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktRatingsMoviesResponseItem>> GetMovieRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncRatingsMoviesRequest(Client) { Rating = rating, Extended = extended });
		}

		public async Task<IEnumerable<TraktRatingsShowsResponseItem>> GetShowRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncRatingsShowsRequest(Client) { Rating = rating, Extended = extended });
		}

		public async Task<IEnumerable<TraktRatingsSeasonsResponseItem>> GetSeasonRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncRatingsSeasonsRequest(Client) { Rating = rating, Extended = extended });
		}

		public async Task<IEnumerable<TraktRatingsEpisodesResponseItem>> GetEpisodeRatingsAsync(Rating rating = Rating.RatingUnspecified, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncRatingsEpisodesRequest(Client) { Rating = rating, Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistMoviesResponseItem>> GetWatchlistMoviesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchlistMoviesRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistShowsResponseItem>> GetWatchlistShowsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchlistShowsRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistSeasonsResponseItem>> GetWatchlistSeasonsAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchlistSeasonsRequest(Client) { Extended = extended });
		}

		public async Task<IEnumerable<TraktWatchlistEpisodesResponseItem>> GetWatchlistEpisodesAsync(ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktSyncWatchlistEpisodesRequest(Client) { Extended = extended });
		}

	}

}