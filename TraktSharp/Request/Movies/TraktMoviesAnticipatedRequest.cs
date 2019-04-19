using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesAnticipatedRequest : TraktGetRequest<IEnumerable<TraktMoviesAnticipatedResponseItem>> {

		internal TraktMoviesAnticipatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/anticipated";

		protected override bool SupportsPagination => true;

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}