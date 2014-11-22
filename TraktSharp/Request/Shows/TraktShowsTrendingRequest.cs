using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response.Shows;

namespace TraktSharp.Request.Shows {

	[Serializable]
	public class TraktShowsTrendingRequest : TraktGetRequest<IEnumerable<TraktShowsTrendingResponseItem>> {

		public TraktShowsTrendingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate {
			get { return "shows/trending"; }
		}

		protected override OAuthRequirementOptions OAuthRequirement {
			get { return OAuthRequirementOptions.NotRequired; }
		}

		protected override bool SupportsPagination {
			get { return true; }
		}

	}

}