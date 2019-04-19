using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsCollectedRequest : TraktGetRequest<IEnumerable<TraktShowsEngagementResponseItem>> {

		internal TraktShowsCollectedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/collected/{period}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		internal TraktReportingPeriod Period { get; set; }

		protected override bool SupportsPagination => true;

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"period", Period != TraktReportingPeriod.Unspecified ? TraktEnumHelper.GetDescription(Period) : string.Empty}
			};

	}

}