using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Entities.RequestBody.Users;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListsUpdateRequest : TraktPutByUsernameAndIdRequest<TraktList, TraktListRequestBody> {

		internal TraktUsersListsUpdateRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}"; } }

	}

}