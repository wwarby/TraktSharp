using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Shows {

	internal class TraktShowsProgressCollectionRequest : TraktGetByIdRequest<TraktShowProgress> {

		internal TraktShowsProgressCollectionRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate => "shows/{id}/progress/collection";

		protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

	}

}