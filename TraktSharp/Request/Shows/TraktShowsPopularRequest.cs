using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TraktSharp.Response;

namespace TraktSharp.Request.Shows {

	[Serializable]
	public class TraktShowsPopularRequest : TraktRequest<IEnumerable<TraktShow>> {

		public TraktShowsPopularRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Get; } }

		protected override string PathTemplate { get { return "shows/popular"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}