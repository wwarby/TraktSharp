using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Request.People {

	public class TraktPeopleMoviesRequest : TraktGetByIdRequest<TraktMovieCredits> {

		public TraktPeopleMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "people/{id}/movies"; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.NotRequired; } }

	}

}