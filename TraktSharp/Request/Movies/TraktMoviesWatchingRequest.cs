using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Movies {

	internal class TraktMoviesWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		internal TraktMoviesWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "movies/{id}/watching";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}