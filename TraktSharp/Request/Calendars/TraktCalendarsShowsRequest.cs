using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Calendars {

	[Serializable]
	public class TraktCalendarsShowsRequest : TraktGetRequest<TraktCalendarsShowsResponse> {

		public TraktCalendarsShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "calendars/shows/{start_date}/{days}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Optional; } }

		protected override bool SupportsPagination { get { return false; } }
		
		public DateTime? StartDate { get; set; }

		public int? Days { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{ "start_date", StartDate.ToTraktApiFormat() },
				{ "days", Days.ToString() }
			};
		}

	}

}