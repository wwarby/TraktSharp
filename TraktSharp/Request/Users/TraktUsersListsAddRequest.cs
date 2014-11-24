using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersListsAddRequest : TraktPostByUsernameRequest<TraktList, TraktListRequestBody> {

		public TraktUsersListsAddRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (RequestBody != null && string.IsNullOrEmpty(RequestBody.Name)) {
				throw new ArgumentException("List name not set.");
			}
		}

	}

}