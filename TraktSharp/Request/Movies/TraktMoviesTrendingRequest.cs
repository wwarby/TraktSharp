using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;

namespace TraktSharp.Request.Movies {

	[Serializable]
	public class TraktMoviesTrendingRequest : TraktGetRequest<IEnumerable<TraktMoviesTrendingResponseItem>> {

		public TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/trending"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}