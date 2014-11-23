using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response.Sync;

namespace TraktSharp.Request.Sync {

	public class TraktSyncRatingsAddRequest : TraktPostRequest<TraktSyncAddResponse, TraktSyncRatingsAddRequestBody> {

		public TraktSyncRatingsAddRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "sync/ratings"; } }

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if ((RequestBody.IsPostable())) {
				throw new ArgumentException("At least one movie, show or episode must be included in the request.");
			}
		}

	}

}