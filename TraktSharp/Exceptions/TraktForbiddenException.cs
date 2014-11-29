using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktForbiddenException : TraktException {

		public TraktForbiddenException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Forbidden - invalid API key",
				HttpStatusCode.Forbidden, traktError, requestUrl, requestBody, responseBody) { }

	}

}