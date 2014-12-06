using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsRepliesRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktCommentsRepliesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/replies"; } }

		protected override bool SupportsPagination { get { return true; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}