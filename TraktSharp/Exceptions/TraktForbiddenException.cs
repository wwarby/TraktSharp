using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktForbiddenException : TraktException {

		public TraktForbiddenException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Forbidden - invalid API key", HttpStatusCode.Forbidden, traktError, requestUrl, requestBody) {
		}

	}

}