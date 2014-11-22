using System;
using System.Linq;
using System.Net;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	public class TraktMethodNotFoundException : TraktException {

		public TraktMethodNotFoundException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base("Method Not Found - method doesn't exist", HttpStatusCode.MethodNotAllowed, traktError, requestUrl, requestBody, responseBody) { }

	}

}