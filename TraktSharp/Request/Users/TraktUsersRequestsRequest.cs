using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	internal class TraktUsersRequestsRequest : TraktGetRequest<IEnumerable<TraktFollowRequest>> {

		internal TraktUsersRequestsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/requests"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}