using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Users;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	internal class TraktUsersListItemsRemoveRequest : TraktPostByUsernameAndIdRequest<TraktRemoveResponse, TraktUsersListItemsRemoveRequestBody> {

		internal TraktUsersListItemsRemoveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "users/{username}/lists/{id}/items/remove";

    protected override void ValidateParameters() {
			base.ValidateParameters();
			if (!RequestBody.IsPostable()) {
				throw new ArgumentException("At least one movie, show, season, episode or person must be included in the request.");
			}
		}

	}

}