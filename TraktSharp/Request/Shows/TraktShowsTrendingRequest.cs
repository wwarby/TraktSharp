using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	public class TraktShowsTrendingRequest : TraktGetRequest<IEnumerable<TraktShowsTrendingResponseItem>> {

		public TraktShowsTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/trending"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}