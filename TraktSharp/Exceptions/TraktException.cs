using System;
using System.Linq;
using System.Net;
using TraktSharp.Response;

namespace TraktSharp.Exceptions {

	public class TraktException : Exception {

		public HttpStatusCode StatusCode { get; set; }
		public string TraktErrorType { get; set; }
		public string RequestUrl { get; set; }
		public string RequestBody { get; set; }

		public TraktException(string message, HttpStatusCode statusCode, TraktErrorResponse traktError, string requestUrl, string requestBody = null) : base(message) {
			StatusCode = statusCode;
			TraktErrorType = traktError.Error;
			RequestUrl = requestUrl;
			RequestBody = requestBody;
		}

	}

}