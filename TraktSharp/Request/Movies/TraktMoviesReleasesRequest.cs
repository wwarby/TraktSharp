using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;

namespace TraktSharp.Request.Movies {

	[Serializable]
	public class TraktMoviesReleasesRequest : TraktGetRequest<IEnumerable<TraktMoviesReleasesResponseItem>> {

		public TraktMoviesReleasesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate {
			get { return "movies/{id}/translations/{language}"; }
		}

		protected override OAuthRequirementOptions OAuthRequirement {
			get { return OAuthRequirementOptions.NotRequired; }
		}

		protected override bool SupportsPagination {
			get { return false; }
		}

		public string Id { get; set; }

		public string Language { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return new Dictionary<string, string> {
				{"id", Id},
				{"language", Language},
			};
		}

		protected override void ValidateParameters() {
			if (string.IsNullOrEmpty(Id)) {
				throw new ArgumentException("Id not set.");
			}
			if (string.IsNullOrEmpty(Language)) {
				throw new ArgumentException("Language not set.");
			}
		}

	}

}