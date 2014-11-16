using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktServiceUnavailableException : TraktException {

		public TraktServiceUnavailableException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Service Unavailable - server overloaded", HttpStatusCode.ServiceUnavailable, traktError, requestUrl, requestBody) {
		}

	}

}