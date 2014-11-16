using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktConflictException : TraktException {

		public TraktConflictException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Conflict - resource already created", HttpStatusCode.Conflict, traktError, requestUrl, requestBody) {
		}

	}

}