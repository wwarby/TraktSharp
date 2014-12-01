using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Calendars {

	public class TraktCalendarsShowsPremieresRequest : TraktGetRequest<TraktCalendarsShowsResponse> {

		public TraktCalendarsShowsPremieresRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "calendars/shows/premieres/{start_date}/{days}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Optional; } }

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