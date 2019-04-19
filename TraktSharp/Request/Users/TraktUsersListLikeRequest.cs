﻿using System;
using System.Linq;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListLikeRequest : TraktBodylessPostByUsernameAndIdRequest<object> {

		internal TraktUsersListLikeRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}/like";

	}

}