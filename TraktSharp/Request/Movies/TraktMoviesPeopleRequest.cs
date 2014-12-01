using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesPeopleRequest : TraktGetByIdRequest<TraktPeople> {

		public TraktMoviesPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/people"; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.NotRequired; } }

	}

}