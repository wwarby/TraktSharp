using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesSummaryRequest : TraktGetByIdRequest<TraktMovie> {

		public TraktMoviesSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}