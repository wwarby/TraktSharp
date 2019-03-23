using System;
using System.Linq;
using System.Net.Http;
using TraktSharp.Enums;

namespace TraktSharp.Request {

	internal abstract class TraktPutRequest<TResponse, TRequestBody> : TraktRequest<TResponse, TRequestBody> where TRequestBody : class {

		protected TraktPutRequest(TraktClient client) : base(client) { }

		protected override HttpMethod Method => HttpMethod.Put;

    protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

    protected override void ValidateParameters() {
			if (RequestBody == null) {
				throw new ArgumentException("Request body not set");
			}
		}

	}

}