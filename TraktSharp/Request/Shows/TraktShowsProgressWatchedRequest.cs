using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsProgressWatchedRequest : TraktGetByIdRequest<TraktShowProgress> {

		public TraktShowsProgressWatchedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/progress/watched"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}