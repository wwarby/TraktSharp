using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktNotFoundException : TraktException {

		public TraktNotFoundException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Not Found - method exists, but no record found",
				HttpStatusCode.NotFound, traktError, requestUrl, requestBody, responseBody) { }

	}

}