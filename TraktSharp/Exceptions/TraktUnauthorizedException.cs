using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktUnauthorizedException : TraktException {

		public TraktUnauthorizedException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Unauthorized - OAuth must be provided", 
				HttpStatusCode.Unauthorized, traktError, requestUrl, requestBody, responseBody) { }

	}

}