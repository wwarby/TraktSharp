using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		internal TraktMoviesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/watching"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}