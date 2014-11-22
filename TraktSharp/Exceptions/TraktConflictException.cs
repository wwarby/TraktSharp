using System;
using System.Linq;
using System.Net;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	public class TraktConflictException : TraktException {

		public TraktConflictException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null, DateTime? expiresAt = null)
			: base("Conflict - resource already created", HttpStatusCode.Conflict, traktError, requestUrl, requestBody, responseBody) { ExpiresAt = expiresAt; }

		public DateTime? ExpiresAt { get; set; }

	}

}