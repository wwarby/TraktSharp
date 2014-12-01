using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.People {

	public class TraktPeopleSummaryRequest : TraktGetByIdRequest<TraktPerson> {

		public TraktPeopleSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}