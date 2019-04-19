using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListsAddRequest : TraktPostByUsernameRequest<TraktList, TraktListRequestBody> {

		internal TraktUsersListsAddRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if ((RequestBody != null) && string.IsNullOrEmpty(RequestBody.Name)) {
				throw new ArgumentException("List name not set.");
			}
		}

	}

}