using System;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsReplyRequest : TraktPostByIdRequest<TraktComment, TraktComment> {

		internal TraktCommentsReplyRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments/{id}/replies";

    protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
		}

	}

}