using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsProgressWatchedRequest : TraktGetByIdRequest<TraktShowProgress> {

		public TraktShowsProgressWatchedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/progress/watched"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

	}

}