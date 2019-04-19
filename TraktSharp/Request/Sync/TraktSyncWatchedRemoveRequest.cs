using System;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchedRemoveRequest : TraktPostRequest<TraktRemoveResponse, TraktSyncRemoveRequestBody> {

		internal TraktSyncWatchedRemoveRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/history/remove";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (!RequestBody.IsPostable()) {
				throw new ArgumentException("At least one movie, show or episode must be included in the request.");
			}
		}

	}

}