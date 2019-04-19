using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersRequestsApproveRequest : TraktBodylessPostByIdRequest<TraktUsersFollowResponse> {

		internal TraktUsersRequestsApproveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/requests/{id}";

  }

}