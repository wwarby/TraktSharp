using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesSummaryRequest : TraktGetByIdRequest<TraktMovie> {

		internal TraktMoviesSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}