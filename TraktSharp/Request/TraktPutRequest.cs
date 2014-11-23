using System;
using System.Linq;
using System.Net.Http;

namespace TraktSharp.Request {

	public abstract class TraktPutRequest<TResponse, TRequestBody> : TraktRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPutRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method { get { return HttpMethod.Put; } }

		protected override OAuthRequirement OAuthRequirement { get { return OAuthRequirement.Required; } }

		protected override void ValidateParameters() {
			if (RequestBody == null) {
				throw new ArgumentException("Request body not set");
			}
		}

	}

}