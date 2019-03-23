using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.People {

	internal class TraktPeopleMoviesRequest : TraktGetByIdRequest<TraktMovieCredits> {

		internal TraktPeopleMoviesRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "people/{id}/movies";

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}