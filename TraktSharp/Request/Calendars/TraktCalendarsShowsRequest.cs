using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.ExtensionMethods;
using TraktSharp.Response.Calendars;

namespace TraktSharp.Request.Calendars {

	[Serializable]
	public class TraktCalendarsShowsRequest : TraktRequest<TraktCalendarsShowsResponse> {

		public TraktCalendarsShowsRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "calendars/shows/{start_date}/{days}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Optional; } }

		protected override bool SupportsPagination { get { return false; } }
		
		public DateTime? StartDate { get; set; }

		public int? Days { get; set; }

		protected override IDictionary<string, string> GetPathParameters(IDictionary<string, string> pathParameters) {
			return new Dictionary<string, string> {
				{ "start_date", StartDate.ToTraktApiFormat() },
				{ "days", Days.ToString() }
			};
		}

	}

}