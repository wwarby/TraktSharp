using System.Collections.Generic;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchedShowsRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchedShowsResponseItem>> {

		internal TraktUsersWatchedShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watched/shows";

  }

}