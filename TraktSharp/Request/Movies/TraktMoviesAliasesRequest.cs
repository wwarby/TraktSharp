using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesAliasesRequest : TraktGetByIdRequest<IEnumerable<TraktMoviesAliasesResponseItem>> {

		public TraktMoviesAliasesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/aliases"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}