using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktMethodNotFoundException : TraktException {

		public TraktMethodNotFoundException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Method Not Found - method doesn't exist",
				HttpStatusCode.MethodNotAllowed, traktError, requestUrl, requestBody, responseBody) { }

	}

}