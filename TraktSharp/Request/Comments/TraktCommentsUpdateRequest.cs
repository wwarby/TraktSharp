using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsUpdateRequest : TraktPutByIdRequest<TraktComment, TraktComment> {

		internal TraktCommentsUpdateRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments/{id}";

    protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
		}

	}

}