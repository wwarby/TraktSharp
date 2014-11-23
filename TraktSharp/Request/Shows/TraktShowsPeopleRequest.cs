using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Shows {

	public class TraktShowsPeopleRequest : TraktGetByIdRequest<TraktPeople> {

		public TraktShowsPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "shows/{id}/people"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}