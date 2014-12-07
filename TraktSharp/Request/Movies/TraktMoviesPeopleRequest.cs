using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesPeopleRequest : TraktGetByIdRequest<TraktCastAndCrew> {

		internal TraktMoviesPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/people"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}