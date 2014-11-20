using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;
using TraktSharp.Request.Checkin;

namespace TraktSharp.Modules {

	public class TraktCheckin {

		public TraktCheckin(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktCheckinMovieResponse> CheckinItemAsync(TraktMovie movie, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
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

		public async Task<TraktCheckinEpisodeResponse> CheckinItemAsync(TraktEpisode episode, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCheckinEpisodeRequest(Client) {
				RequestBody = new TraktCheckinEpisodeRequestBody {
					Episode = episode,
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

		public async Task<TraktCheckinEpisodeResponse> CheckinItemAsync(string showTitle, int season, int episode, TraktSharingOptions sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCheckinEpisodeRequest(Client) {
				RequestBody = new TraktCheckinEpisodeRequestBody {
					Show = new TraktShow { Title = showTitle },
					Episode = new TraktEpisode { Season = season, Number = episode },
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