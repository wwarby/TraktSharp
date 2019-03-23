using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsRepliesRequest : TraktGetByIdRequest<IEnumerable<TraktComment>> {

		internal TraktCommentsRepliesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments/{id}/replies";

    protected override bool SupportsPagination => true;

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}