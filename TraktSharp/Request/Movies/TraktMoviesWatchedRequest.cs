using System.Collections.Generic;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;
using TraktSharp.Helpers;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesWatchedRequest : TraktGetRequest<IEnumerable<TraktMoviesEngagementResponseItem>> {

		internal TraktMoviesWatchedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/watched/{period}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

		internal TraktReportingPeriod Period { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"period", Period != TraktReportingPeriod.Unspecified ? TraktEnumHelper.GetDescription(Period) : string.Empty}
			};

	}

}