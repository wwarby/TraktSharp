using System;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncWatchlistAddRequest : TraktPostRequest<TraktAddResponse, TraktSyncWatchlistAddRequestBody> {

		internal TraktSyncWatchlistAddRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/watchlist";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (!RequestBody.IsPostable()) {
				throw new ArgumentException("At least one movie, show or episode must be included in the request.");
			}
		}

	}

}