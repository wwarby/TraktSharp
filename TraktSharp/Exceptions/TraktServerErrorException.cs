using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	[Serializable, DataContract]
	public class TraktServerErrorException : TraktException {

		public TraktServerErrorException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base(traktError != null && !string.IsNullOrEmpty(traktError.Description) ? traktError.Description : "Server Error",
				HttpStatusCode.InternalServerError, traktError, requestUrl, requestBody, responseBody) { }

	}

}