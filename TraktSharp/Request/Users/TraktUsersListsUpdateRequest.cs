using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;

namespace TraktSharp.Request.Users {

	public class TraktUsersListsUpdateRequest : TraktPutByUsernameAndIdRequest<TraktList, TraktListRequestBody> {

		public TraktUsersListsUpdateRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}