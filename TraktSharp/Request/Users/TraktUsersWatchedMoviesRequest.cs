﻿using System.Collections.Generic;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersWatchedMoviesRequest : TraktGetByUsernameRequest<IEnumerable<TraktWatchedMoviesResponseItem>> {

		internal TraktUsersWatchedMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/watched/movies";

  }

}