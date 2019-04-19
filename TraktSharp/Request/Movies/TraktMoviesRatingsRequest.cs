using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesRatingsRequest : TraktGetByIdRequest<TraktRatings> {

		internal TraktMoviesRatingsRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/ratings";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

	}

}