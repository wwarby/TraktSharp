using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	public class TraktShowsCommentsRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		public TraktShowsCommentsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/comments"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

		protected override bool SupportsPagination { get { return true; } }

	}

}