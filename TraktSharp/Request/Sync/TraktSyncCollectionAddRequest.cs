﻿using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Sync;
using TraktSharp.Entities.Response;

namespace TraktSharp.Request.Sync {

	internal class TraktSyncCollectionAddRequest : TraktPostRequest<TraktAddResponse, TraktSyncCollectionAddRequestBody> {

		internal TraktSyncCollectionAddRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "sync/collection";

    protected override void ValidateParameters() {
			base.ValidateParameters();
			if (!RequestBody.IsPostable()) {
				throw new ArgumentException("At least one movie, show or episode must be included in the request.");
			}
		}

	}

}