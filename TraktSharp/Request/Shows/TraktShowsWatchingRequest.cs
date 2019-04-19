using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsWatchingRequest : TraktGetByIdRequest<IEnumerable<TraktUser>> {

		internal TraktShowsWatchingRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/watching";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}