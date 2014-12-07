using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		internal TraktShowsWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/watching"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}