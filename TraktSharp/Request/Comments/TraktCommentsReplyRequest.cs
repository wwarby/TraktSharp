using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsReplyRequest : TraktPostByIdRequest<TraktComment, TraktComment> {

		internal TraktCommentsReplyRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}/replies"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
		}

	}

}