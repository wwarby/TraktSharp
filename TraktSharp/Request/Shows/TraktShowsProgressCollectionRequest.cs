using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsProgressCollectionRequest : TraktGetByIdRequest<TraktShowProgress> {

		public TraktShowsProgressCollectionRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/progress/collection"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}