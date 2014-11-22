using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	[Serializable]
	public class TraktCommentsPostMovieRequest : TraktPostRequest<TraktComment> {

		public TraktCommentsPostMovieRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate {
			get { return "comments"; }
		}

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktMovieComment;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof (TraktMovieComment).Name));
			}
			if (string.IsNullOrEmpty(requestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}
			if (requestBody.Movie == null) {
				throw new ArgumentException("Movie not set");
			}
			if (requestBody.Movie.IsPostable()) {
				throw new ArgumentException("Either movie title and year or at least one id value must be set");
			}
		}

	}

}