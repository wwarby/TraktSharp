using System;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsPostShowRequest : TraktPostRequest<TraktComment, TraktShowComment> {

		internal TraktCommentsPostShowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments";

    protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (RequestBody.Show == null) {
				throw new ArgumentException("Show not set");
			}
			if (!RequestBody.Show.IsPostable()) {
				throw new ArgumentException("Either show title or at least one id value must be set");
			}
		}

	}

}