using System.Collections.Generic;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesBoxOfficeRequest : TraktGetRequest<IEnumerable<TraktMoviesBoxOfficeResponseItem>> {

		internal TraktMoviesBoxOfficeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/boxoffice";

		protected override bool SupportsPagination => false;

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}