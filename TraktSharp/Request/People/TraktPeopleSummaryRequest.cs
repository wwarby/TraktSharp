using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.People {

	internal class TraktPeopleSummaryRequest : TraktGetByIdRequest<TraktPerson> {

		internal TraktPeopleSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}