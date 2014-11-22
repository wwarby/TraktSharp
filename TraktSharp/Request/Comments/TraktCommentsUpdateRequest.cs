using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsUpdateRequest : TraktPutByIdRequest<TraktComment> {

		public TraktCommentsUpdateRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			var requestBody = RequestBody as TraktComment;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof(TraktComment).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
		}

	}

}