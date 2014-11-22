using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.People {

	public class TraktPeopleSummaryRequest : TraktGetByIdRequest<TraktPerson> {

		public TraktPeopleSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}