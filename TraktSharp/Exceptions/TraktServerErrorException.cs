using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktServerErrorException : TraktException {

		public TraktServerErrorException(TraktErrorResponse traktError, string requestUrl, string requestBody = null)
			: base("Server Error", HttpStatusCode.InternalServerError, traktError, requestUrl, requestBody) {
		}

	}

}