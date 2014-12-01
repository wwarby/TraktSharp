using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesTranslationsRequest : TraktGetByIdRequest<IEnumerable<TraktMoviesTranslationsResponseItem>> {

		public TraktMoviesTranslationsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/translations/{language}"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		public string Language { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) {
			return base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"language", Language}
			});
		}

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Language)) {
				throw new ArgumentException("Language not set.");
			}
		}

	}

}