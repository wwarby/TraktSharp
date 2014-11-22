using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	[Serializable]
	public class TraktCommentsPostListRequest : TraktPostRequest<TraktComment> {

		public TraktCommentsPostListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate {
			get { return "comments"; }
		}

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktListComment;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof (TraktListComment).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (requestBody.List == null) {
				throw new ArgumentException("List not set");
			}
			if (!requestBody.List.IsPostable()) {
				throw new ArgumentException("At least one list id value must be set");
			}
		}

	}

}