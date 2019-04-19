namespace TraktSharp.Request.Users {

	internal class TraktUsersRequestsDenyRequest : TraktDeleteByIdRequest {

		internal TraktUsersRequestsDenyRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/requests/{id}";

	}

}