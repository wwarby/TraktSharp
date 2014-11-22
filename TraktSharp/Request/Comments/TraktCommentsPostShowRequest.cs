using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	public class TraktCommentsPostShowRequest : TraktPostRequest<TraktComment, TraktShowComment> {

		public TraktCommentsPostShowRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments"; } }

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