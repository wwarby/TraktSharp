using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesTrendingRequest : TraktGetRequest<IEnumerable<TraktMoviesTrendingResponseItem>> {

		public TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/trending"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}