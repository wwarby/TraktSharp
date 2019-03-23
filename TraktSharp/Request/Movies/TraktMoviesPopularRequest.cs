using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesPopularRequest : TraktGetRequest<IEnumerable<TraktMovie>> {

		internal TraktMoviesPopularRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/popular";

    protected override bool SupportsPagination => true;

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}