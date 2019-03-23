using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;
using TraktSharp.ExtensionMethods;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesUpdatesRequest : TraktGetRequest<IEnumerable<TraktMoviesUpdatesResponseItem>> {

		internal TraktMoviesUpdatesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/updates/{start_date}";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    protected override bool SupportsPagination => true;

    internal DateTime? StartDate { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			new Dictionary<string, string> {
				{"start_date", StartDate.ToTraktApiFormat()}
			};

	}

}