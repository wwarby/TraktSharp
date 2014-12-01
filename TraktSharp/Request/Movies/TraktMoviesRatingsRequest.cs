using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesRatingsRequest : TraktGetByIdRequest<TraktRatings> {

		public TraktMoviesRatingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/ratings"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}