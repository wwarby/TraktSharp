using System.Collections.Generic;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsPlayedRequest : TraktGetRequest<IEnumerable<TraktShowsEngagementResponseItem>> {

		internal TraktShowsPlayedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/played/{period}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		internal TraktReportingPeriod Period { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"period", Period != TraktReportingPeriod.Unspecified ? TraktEnumHelper.GetDescription(Period) : string.Empty}
			};

		protected override bool SupportsPagination => true;

	}

}