using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsPostMovieRequest : TraktPostRequest<TraktComment, TraktMovieComment> {

		internal TraktCommentsPostMovieRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (string.IsNullOrEmpty(RequestBody.Comment)) {
				throw new ArgumentException("Comment not set");
			}

			if (RequestBody.Movie == null) {
				throw new ArgumentException("Movie not set");
			}

			if (!RequestBody.Movie.IsPostable()) {
				throw new ArgumentException("Either movie title and year or at least one id value must be set");
			}
		}

	}

}