using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	public abstract class TraktPostRequest<TResponse, TRequestBody> : TraktRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPostRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Post; } }

		protected override OAuthRequirementOptions OAuthRequirement { get { return OAuthRequirementOptions.Required; } }

		protected override bool SupportsPagination { get { return false; } }

		protected override void ValidateParameters() {
			if (RequestBody == null) {
				throw new ArgumentException("Request body not set");
			}
		}

	}

}