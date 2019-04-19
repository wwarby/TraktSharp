using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktShowsCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/comments";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

	}

}