using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsPostListRequest : TraktPostRequest<TraktComment, TraktListComment> {

		public TraktCommentsPostListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (RequestBody.List == null) {
				throw new ArgumentException("List not set");
			}
			if (!RequestBody.List.IsPostable()) {
				throw new ArgumentException("At least one list id value must be set");
			}
		}

	}

}