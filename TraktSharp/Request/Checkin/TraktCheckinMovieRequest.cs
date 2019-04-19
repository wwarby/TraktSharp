using System;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;

namespace TraktSharp.Request.Checkin {

	internal class TraktCheckinMovieRequest : TraktPostRequest<TraktCheckinMovieResponse, TraktCheckinMovieRequestBody> {

		internal TraktCheckinMovieRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "checkin";

		protected override void ValidateParameters() {
			base.ValidateParameters();
			if (RequestBody.Movie == null) {
				throw new ArgumentException("Movie not set");
			}
			if (!RequestBody.Movie.IsPostable()) {
				throw new ArgumentException("Either movie title and year or at least one id value must be set");
			}
		}

	}

}