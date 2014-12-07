using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsRatingsRequest : TraktGetByIdRequest<TraktRatings> {

		internal TraktShowsRatingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/ratings"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}