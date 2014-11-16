using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktNotFoundException : TraktException {

		public TraktNotFoundException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Not Found - method exists, but no record found", HttpStatusCode.NotFound, traktError, requestUrl, requestBody) {
		}

	}

}