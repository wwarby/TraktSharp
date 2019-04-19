using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktMovie>> {

		internal TraktMoviesRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/related";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}