using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsPostEpisodeRequest : TraktPostRequest<TraktComment, TraktEpisodeComment> {

		internal TraktCommentsPostEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (RequestBody.Episode == null) {
				throw new ArgumentException("Episode not set");
			}
			if (!RequestBody.Episode.IsPostable()) {
				throw new ArgumentException("At least one episode id value must be set");
			}
		}

	}

}