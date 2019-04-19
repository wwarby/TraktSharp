using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktMoviesCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/comments";

		protected override bool SupportsPagination => true;

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}