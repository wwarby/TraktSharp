using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersListItemsRequest : TraktGetByUsernameAndIdRequest<IEnumerable<TraktListItemsResponseItem>> {

		public TraktUsersListItemsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}/items"; } }

	}

}