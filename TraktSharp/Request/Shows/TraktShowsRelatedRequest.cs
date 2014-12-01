using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	public class TraktShowsRelatedRequest : TraktGetByIdRequest<IEnumerable<TraktShow>> {

		public TraktShowsRelatedRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/related"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}