using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Request.Calendars;

namespace TraktSharp.Modules {

	public class TraktCalendarsModule {

		public TraktCalendarsModule(TraktClient client) { Client = client; }

		public TraktClient Client { get; private set; }

		public async Task<TraktCalendarsShowsResponse> GetShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCalendarsShowsRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> GetNewShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCalendarsShowsNewRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsShowsResponse> GetPremiereShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCalendarsShowsPremieresRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

		public async Task<TraktCalendarsMoviesResponse> GetMoviesAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await new TraktCalendarsMoviesRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			}.SendAsync();
		}

	}

}