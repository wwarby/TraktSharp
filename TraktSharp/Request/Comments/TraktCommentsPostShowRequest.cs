using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	[Serializable]
	public class TraktCommentsPostShowRequest : TraktPostRequest<TraktComment> {

		public TraktCommentsPostShowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments"; } }

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktShowComment;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof (TraktShowComment).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (requestBody.Show == null) {
				throw new ArgumentException("Show not set");
			}
			if (!requestBody.Show.IsPostable()) {
				throw new ArgumentException("Either show title or at least one id value must be set");
			}
		}

	}

}