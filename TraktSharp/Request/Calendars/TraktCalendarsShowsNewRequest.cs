using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Calendars {

	public class TraktCalendarsShowsNewRequest : TraktGetRequest<TraktCalendarsShowsResponse> {

		public TraktCalendarsShowsNewRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "calendars/shows/new/{start_date}/{days}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Optional; } }

		public DateTime? StartDate { get; set; }

		public int? Days { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()},
				{"days", Days.ToString()}
			};
		}

	}

}