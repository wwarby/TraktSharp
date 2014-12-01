using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	public class TraktShowsRatingsRequest : TraktGetByIdRequest<TraktRatings> {

		public TraktShowsRatingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/ratings"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}