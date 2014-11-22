using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesSummaryRequest : TraktGetByIdRequest<TraktMovie> {

		public TraktMoviesSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}