using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	[Serializable]
	public abstract class TraktPutRequest<TResponse> : TraktRequest<TResponse> {

		protected TraktPutRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Put; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

		protected override bool SupportsPagination { get { return false; } }

	}

}