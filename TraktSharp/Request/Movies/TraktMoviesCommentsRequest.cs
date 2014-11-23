using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		public TraktMoviesCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/comments"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}