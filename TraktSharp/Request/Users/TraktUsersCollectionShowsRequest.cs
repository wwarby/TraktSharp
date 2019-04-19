using System.Collections.Generic;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersCollectionShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktCollectionShowsResponseItem>> {

		internal TraktUsersCollectionShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/collection/shows";

	}

}