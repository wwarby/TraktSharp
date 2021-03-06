﻿using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Scrobble;
using TraktSharp.Entities.Response.Scrobble;

namespace TraktSharp.Request.Scrobble {

	internal class TraktScrobbleStopMovieRequest : TraktPostRequest<TraktScrobbleMovieResponse, TraktScrobbleMovieRequestBody> {

		internal TraktScrobbleStopMovieRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "scrobble/stop";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (RequestBody.Movie == null) {
				throw new ArgumentException("Movie not set");
			}

			if ((RequestBody.Progress < 0) || (RequestBody.Progress > 100)) {
				throw new ArgumentException("Progress must be between 0 and 100");
			}

			if (!RequestBody.Movie.IsPostable()) {
				throw new ArgumentException("Either movie title and year or at least one id value must be set");
			}
		}

	}

}