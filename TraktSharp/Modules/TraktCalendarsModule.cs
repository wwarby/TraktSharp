using System;
using System.Linq;
using System.Threading.Tasks;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Request.Calendars;

namespace TraktSharp.Modules {

	public class TraktCalendarsModule : TraktModuleBase {

		public TraktCalendarsModule(TraktClient client) : base(client) { }

		public async Task<TraktCalendarsShowsResponse> GetShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCalendarsShowsRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});
		}

		public async Task<TraktCalendarsShowsResponse> GetNewShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCalendarsShowsNewRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});
		}

		public async Task<TraktCalendarsShowsResponse> GetPremiereShowsAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCalendarsShowsPremieresRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});
		}

		public async Task<TraktCalendarsMoviesResponse> GetMoviesAsync(DateTime? startDate = null, int? days = null, bool authenticate = true, ExtendedOption extended = ExtendedOption.Unspecified) {
			return await SendAsync(new TraktCalendarsMoviesRequest(Client) {
				StartDate = startDate,
				Days = days,
				Authenticate = authenticate,
				Extended = extended
			});
		}

	}

}