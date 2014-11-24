using System;
using System.Linq;
using TraktSharp.Entities.Response.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersRequestsApproveRequest : TraktBodylessPostByIdRequest<TraktUsersRequestsApproveResponse> {

		public TraktUsersRequestsApproveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/requests/{id}"; } }

	}

}