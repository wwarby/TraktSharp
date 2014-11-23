using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;
using TraktSharp.Factories;
using TraktSharp.Request.Checkin;

namespace TraktSharp.Modules {

	public class TraktCheckinModule {

		public TraktCheckinModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktCheckinMovieResponse> MovieAsync(string movieId, StringMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(int movieId, IntMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(string title, int? year, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(TraktMovie movie, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCheckinMovieRequest(Client) {
				RequestBody = new TraktCheckinMovieRequestBody {
					Movie = movie,
					Sharing = sharing,
					Message = message,
					AppVersion = appVersion,
					AppDate = appDate,
					VenueId = venueId,
					VenueName = venueName
				},
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(string showTitle, int? showYear, int season, int episode, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(TraktEpisode episode, TraktShow show = null, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCheckinEpisodeRequest(Client) {
				RequestBody = new TraktCheckinEpisodeRequestBody {
					Episode = episode,
					Show = show,
					Sharing = sharing,
					Message = message,
					AppVersion = appVersion,
					AppDate = appDate,
					VenueId = venueId,
					VenueName = venueName
				},
				Extended = extended
			}.SendAsync();
		}

		public async Task DeleteAsync() {
			await new TraktCheckinDeleteRequest(Client).SendAsync();
		}

	}

}