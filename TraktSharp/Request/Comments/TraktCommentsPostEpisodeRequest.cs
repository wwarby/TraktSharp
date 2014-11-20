using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	[Serializable]
	public class TraktCommentsPostEpisodeRequest : TraktPostRequest<TraktComment> {

		public TraktCommentsPostEpisodeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments"; } }

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktEpisodeComment;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof(TraktEpisodeComment).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (requestBody.Episode == null) {
				throw new ArgumentException("Episode not set");
			}
			if (!requestBody.Episode.IsPostable()) {
				throw new ArgumentException("At least one episode id value must be set");
			}
		}

	}

}