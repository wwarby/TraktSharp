using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		public TraktMoviesCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/comments"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}