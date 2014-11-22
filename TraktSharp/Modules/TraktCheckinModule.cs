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

		public async Task<TraktCheckinMovieResponse> MovieAsync(string id, StringMovieIdType type, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromId(id, type), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(int id, IntMovieIdType type, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromId(id, type), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(string title, int? year, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await MovieAsync(TraktMovieFactory.FromTitleAndYear(title, year), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinMovieResponse> MovieAsync(TraktMovie movie, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
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

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(string id, StringEpisodeIdType type, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromId(id, type), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(int id, IntEpisodeIdType type, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromId(id, type), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(string showTitle, int? showYear, int season, int episode, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await EpisodeAsync(TraktEpisodeFactory.FromSeasonAndNumber(season, episode), TraktShowFactory.FromTitleAndYear(showTitle, showYear), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		public async Task<TraktCheckinEpisodeResponse> EpisodeAsync(TraktEpisode episode, TraktShow show = null, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
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

		public async Task DeleteAsync() { await new TraktCheckinDeleteRequest(Client).SendAsync(); }

	}

}