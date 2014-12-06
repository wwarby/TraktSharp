using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.People {

	internal class TraktPeopleShowsRequest : TraktGetByIdRequest<TraktShowCredits> {

		internal TraktPeopleShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}/shows"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}