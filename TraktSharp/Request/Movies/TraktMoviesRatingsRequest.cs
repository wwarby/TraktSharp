using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesRatingsRequest : TraktGetByIdRequest<TraktRatings> {

		public TraktMoviesRatingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/ratings"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}