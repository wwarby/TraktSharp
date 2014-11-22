using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktShow>> {

		public TraktShowsRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/related"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}