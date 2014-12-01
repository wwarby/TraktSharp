using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;
using TraktSharp.Enums;
using TraktSharp.Factories;
using TraktSharp.Request.Checkin;

namespace TraktSharp.Modules {

	/// <summary>Provides API methods in the Checkin namespace</summary>
	public class TraktCheckinModule : TraktModuleBase {

		/// <summary>Default constructor for the module. Used internally by <see cref="TraktClient"/>.</summary>
		/// <param name="client">The owning instance of <see cref="TraktClient"/></param>
		public TraktCheckinModule(TraktClient client) : base(client) { }

		/// <summary>Check into a movie. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(string movieId, StringMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into a movie. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="movieId">The movie ID</param>
		/// <param name="movieIdType">The movie ID type</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(int movieId, IntMovieIdType movieIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromId(movieId, movieIdType), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into a movie. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="movieTitle">The movie title</param>
		/// <param name="movieYear">The movie release year</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		/// <remarks>This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</remarks>
		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(string movieTitle, int? movieYear, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinMovieAsync(TraktMovieFactory.FromTitleAndYear(movieTitle, movieYear), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into a movie. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="movie">The movie</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinMovieResponse> CheckinMovieAsync(TraktMovie movie, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCheckinMovieRequest(Client) {
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
			});
		}

		/// <summary>Check into an episode. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(string episodeId, StringEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into an episode. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="episodeId">The episode ID</param>
		/// <param name="episodeIdType">The episode ID type</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(int episodeId, IntEpisodeIdType episodeIdType, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromId(episodeId, episodeIdType), null, sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into an episode. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <param name="seasonNumber">The season number</param>
		/// <param name="episodeNumber">The episode number within the specified season</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(string showTitle, int? showYear, int seasonNumber, int episodeNumber, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await CheckinEpisodeAsync(TraktEpisodeFactory.FromSeasonAndEpisodeNumber(seasonNumber, episodeNumber), TraktShowFactory.FromTitleAndYear(showTitle, showYear), sharing, message, venueId, venueName, appVersion, appDate, extended);
		}

		/// <summary>Check into an episode. This should be tied to a user action to manually indicate they are watching something.
		/// The item will display as watching on the site, then automatically switch to watched status once the duration has elapsed.</summary>
		/// <param name="episode">The episode</param>
		/// <param name="show">The show</param>
		/// <param name="sharing">Control sharing to any connected social networks</param>
		/// <param name="message">Message used for sharing. If not sent, it will use the watching string in the user settings.</param>
		/// <param name="venueId">Foursquare venue ID</param>
		/// <param name="venueName">Foursquare venue name</param>
		/// <param name="appVersion">Version number of the app</param>
		/// <param name="appDate">Build date of the app</param>
		/// <param name="extended">Changes which properties are populated for standard media objects. By default, minimal data is returned. Change this if additional fields are required in the returned data.</param>
		/// <returns>See summary</returns>
		public async Task<TraktCheckinEpisodeResponse> CheckinEpisodeAsync(TraktEpisode episode, TraktShow show = null, TraktSharing sharing = null, string message = "", string venueId = "", string venueName = "", string appVersion = "", DateTime? appDate = null, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCheckinEpisodeRequest(Client) {
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
			});
		}

		/// <summary>Removes any active checkins, no need to provide a specific item. Does not return anything.</summary>
		/// <returns>See summary</returns>
		public async Task RemoveActiveCheckinAsync() {
			await SendAsync(new TraktCheckinDeleteRequest(Client));
		}

	}

}