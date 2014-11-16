using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktBadRequestException : TraktException {

		public TraktBadRequestException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Bad Request - request couldn't be parsed", HttpStatusCode.BadRequest, traktError, requestUrl, requestBody) {
		}

	}

}