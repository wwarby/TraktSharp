using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesAliasesRequest : TraktGetRequest<IEnumerable<TraktMoviesAliasesResponseItem>> {

		public TraktMoviesAliasesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/aliases"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return false; } }

		public string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"id", Id}
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}