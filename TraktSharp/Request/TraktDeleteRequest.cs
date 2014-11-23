using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	public abstract class TraktDeleteRequest : TraktRequest<object, object> {

		protected TraktDeleteRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Delete; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

	}

}