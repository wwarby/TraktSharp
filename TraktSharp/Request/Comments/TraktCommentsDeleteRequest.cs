namespace TraktSharp.Request.Comments {

	internal class TraktCommentsDeleteRequest : TraktDeleteByIdRequest {

		internal TraktCommentsDeleteRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "comments/{id}";

	}

}