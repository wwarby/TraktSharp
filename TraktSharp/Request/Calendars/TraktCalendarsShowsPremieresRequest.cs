using System;
using System.Collections.Generic;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Calendars {

	internal class TraktCalendarsShowsPremieresRequest : TraktGetRequest<Dictionary<string, IEnumerable<TraktCalendarsShowsResponseItem>>> {

		internal TraktCalendarsShowsPremieresRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "calendars/shows/premieres/{start_date}/{days}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Optional;

    internal DateTime? StartDate { get; set; }

		internal int? Days { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()},
				{"days", Days.ToString()}
			};

	}

}