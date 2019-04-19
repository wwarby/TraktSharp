using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesPeopleRequest : TraktGetByIdRequest<TraktCastAndCrew> {

		internal TraktMoviesPeopleRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/people";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}