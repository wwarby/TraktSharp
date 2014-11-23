using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsRepliesRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		public TraktCommentsRepliesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/replies"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}