using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesPopularRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		public TraktMoviesPopularRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/popular"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}