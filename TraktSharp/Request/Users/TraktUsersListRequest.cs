using TraktSharp.Entities;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListRequest : TraktGetByUsernameAndIdRequest<TraktList> {

		internal TraktUsersListRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}";

  }

}