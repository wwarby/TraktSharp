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

		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(string movieId, StringMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(int movieId, IntMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(string title, int? year, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(TraktMovie movie, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
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

		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(string showTitle, int? showYear, int season, int episode, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(TraktEpisode episode, TraktShow show = null, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
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

		public async Task RemoveActiveCheckinAsync() {
			await new TraktCheckinDeleteRequest(Client).SendAsync();
		}

	}

}