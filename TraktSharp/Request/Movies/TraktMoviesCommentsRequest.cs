using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktMoviesCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/comments"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}