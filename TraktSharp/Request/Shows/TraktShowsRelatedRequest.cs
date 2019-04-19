using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktShow>> {

		internal TraktShowsRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/related";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}