using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktServiceUnavailableException : TraktException {

		public TraktServiceUnavailableException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Service Unavailable - server overloaded",
				HttpStatusCode.ServiceUnavailable, traktError, requestUrl, requestBody, responseBody) { }

	}

}