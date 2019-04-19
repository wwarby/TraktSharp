using TraktSharp.Entities;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsLikeRequest : TraktBodylessPostByIdRequest<TraktComment> {

		internal TraktCommentsLikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments/{id}/like";

	}

}