using System;
using System.Linq;
using TraktSharp.Entities.RequestBody.Checkin;
using TraktSharp.Entities.Response.Checkin;

namespace TraktSharp.Request.Checkin {

	[Serializable]
	public class TraktCheckinMovieRequest : TraktPostRequest<TraktCheckinMovieResponse> {

		public TraktCheckinMovieRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "checkin"; } }

		protected override void ValidateParameters() {
			var requestBody = RequestBody as TraktCheckinMovieRequestBody;
			if (requestBody == null) {
				throw new ArgumentException(string.Format("Request body not set or not an instance of {0}", typeof (TraktCheckinMovieRequestBody).Name));
			}
			if (requestBody.Movie == null) {
				throw new ArgumentException("Movie not set");
			}
			if (requestBody.Movie.IsPostable()) {
				throw new ArgumentException("Either movie title and year or at least one id value must be set");
			}
		}

	}

}