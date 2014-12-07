using System;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Request.Comments {

	internal class TraktCommentsGetRequest : TraktGetByIdRequest<TraktComment> {

		internal TraktCommentsGetRequest(TraktClient client) : base(client) { }

		protected override string PathTemplate { get { return "comments/{id}"; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.NotRequired; } }

	}

}