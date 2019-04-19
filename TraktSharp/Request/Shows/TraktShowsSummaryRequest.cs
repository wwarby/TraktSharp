using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsSummaryRequest : TraktGetByIdRequest<TraktShow> {

		internal TraktShowsSummaryRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

  }

}