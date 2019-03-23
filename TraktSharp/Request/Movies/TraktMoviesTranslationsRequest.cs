﻿using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesTranslationsRequest : TraktGetByIdRequest<IEnumerable<TraktMoviesTranslationsResponseItem>> {

		internal TraktMoviesTranslationsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/translations/{language}";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

    internal string Language { get; set; }

		protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters(IEnumerable<KeyValuePair<string, string>> pathParameters) =>
			base.GetPathParameters(pathParameters).Union(new Dictionary<string, string> {
				{"language", Language}
			});

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(Language)) {
				throw new ArgumentException("Language not set.");
			}
		}

	}

}