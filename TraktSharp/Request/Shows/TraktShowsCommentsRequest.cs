using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsCommentsRequest : TraktGetRequest<IEnumerable<TraktComment>> {

		public TraktShowsCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/comments"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

		public string Id { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{ "id", Id }
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
		}

	}

}