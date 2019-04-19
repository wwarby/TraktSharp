using System.Collections.Generic;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersCollectionMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktCollectionMoviesResponseItem>> {

		internal TraktUsersCollectionMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/collection/movies";

  }

}