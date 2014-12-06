using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsTrendingRequest : TraktGetRequest<IEnumerable<TraktShowsTrendingResponseItem>> {

		internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/trending"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}