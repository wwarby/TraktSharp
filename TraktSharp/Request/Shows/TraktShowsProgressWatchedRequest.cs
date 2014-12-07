using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsProgressWatchedRequest : TraktGetByIdRequest<TraktShowProgress> {

		internal TraktShowsProgressWatchedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/progress/watched"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

	}

}