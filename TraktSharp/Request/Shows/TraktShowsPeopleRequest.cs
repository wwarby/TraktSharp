using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsPeopleRequest : TraktGetByIdRequest<TraktCastAndCrew> {

		internal TraktShowsPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/people";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}