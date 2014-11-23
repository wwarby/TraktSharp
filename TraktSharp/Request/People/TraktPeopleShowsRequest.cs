using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.People {

	public class TraktPeopleShowsRequest : TraktGetByIdRequest<TraktShowCredits> {

		public TraktPeopleShowsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}/shows"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}