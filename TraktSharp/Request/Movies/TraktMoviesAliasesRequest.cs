using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesAliasesRequest : TraktGetByIdRequest<IEnumerable<TraktMoviesAliasesResponseItem>> {

		internal TraktMoviesAliasesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/aliases"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}