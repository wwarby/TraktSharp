using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Seasons {

	public class TraktSeasonsSummaryRequest : TraktGetByIdRequest<TraktSeason> {

		public TraktSeasonsSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/seasons"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}