using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsPopularRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		public TraktShowsPopularRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/popular"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}