using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	public class TraktUsersRequestsRequest : TraktGetRequest<IEnumerable<TraktFollowRequest>> {

		public TraktUsersRequestsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/requests"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}