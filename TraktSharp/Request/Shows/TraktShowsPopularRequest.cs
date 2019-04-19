using System.Collections.Generic;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsPopularRequest : TraktGetRequest<IEnumerable<TraktShow>> {

		internal TraktShowsPopularRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/popular";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

		protected override bool SupportsPagination => true;

  }

}