using System.Collections.Generic;
using TraktSharp.Entities.Response.Movies;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesTrendingRequest : TraktGetRequest<IEnumerable<TraktMoviesTrendingResponseItem>> {

		internal TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/trending";

		protected override bool SupportsPagination => true;

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}