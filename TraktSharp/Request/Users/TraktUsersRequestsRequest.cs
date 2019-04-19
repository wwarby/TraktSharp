using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Users {

	internal class TraktUsersRequestsRequest : TraktGetRequest<IEnumerable<TraktFollowRequest>> {

		internal TraktUsersRequestsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/requests";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

  }

}