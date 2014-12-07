using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	internal abstract class TraktBodylessPostRequest<TResponse> : TraktRequest<TResponse, object> {

		protected TraktBodylessPostRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Post; } }

		protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

	}

}