using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	public abstract class TraktDeleteRequest : TraktRequest<object, object> {

		protected TraktDeleteRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Delete; } }

		protected override TraktOAuthRequirement OAuthRequirement { get { return TraktOAuthRequirement.Required; } }

	}

}