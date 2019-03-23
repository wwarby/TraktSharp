using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListItemsRequest : TraktGetByUsernameAndIdRequest<IEnumerable<TraktListItemsResponseItem>> {

		internal TraktUsersListItemsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}/items";

  }

}