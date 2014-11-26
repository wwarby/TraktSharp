using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Users;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Users {

	public class TraktUsersListItemsRemoveRequest : TraktPostByUsernameAndIdRequest<TraktRemoveResponse, TraktUsersListItemsRemoveRequestBody> {

		public TraktUsersListItemsRemoveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "users/{username}/lists/{id}/items/remove"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if ((RequestBody.IsPostable())) {
				throw new ArgumentException("At least one movie, show, season, episode or person must be included in the request.");
			}
		}

	}

}