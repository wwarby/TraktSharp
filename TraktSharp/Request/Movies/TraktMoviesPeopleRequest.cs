using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.Movies {

	public class TraktMoviesPeopleRequest : TraktGetByIdRequest<TraktPeople> {

		public TraktMoviesPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "movies/{id}/people"; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.NotRequired; } }

	}

}