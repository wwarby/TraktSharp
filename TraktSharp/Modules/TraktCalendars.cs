using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Request.Calendars;

namespace TraktSharp.Modules {

	public class TraktCalendars {

		public TraktCalendars(TraktClient client) {
			Client = client;
		}

		public TraktClient Client { get; private set; }

		public async Task<TraktCalendarsShowsResponse> ShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> ShowsNewAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsNewRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> ShowsPremieresAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsShowsPremieresRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsMoviesResponse> MoviesAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOptions extended = ExtendedOptions.Unspecified) {
			return await new TraktCalendarsMoviesRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

	}

}