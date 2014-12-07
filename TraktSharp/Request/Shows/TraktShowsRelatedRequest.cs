using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktShow>> {

		internal TraktShowsRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/related"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}