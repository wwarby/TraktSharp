using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Seasons {

	internal class TraktSeasonsSummaryRequest : TraktGetByIdRequest<IEnumerable<TraktSeason>> {

		internal TraktSeasonsSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/seasons";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}