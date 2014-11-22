﻿using System;
using System.Linq;
using System.Net;
using TraktSharp.Entities;

namespace TraktSharp.Exceptions {

	public class TraktUnauthorizedException : TraktException {

		public TraktUnauthorizedException(TraktErrorResponse traktError, string requestUrl, string requestBody = null, string responseBody = null)
			: base("Unauthorized - OAuth must be provided", HttpStatusCode.Unauthorized, traktError, requestUrl, requestBody, responseBody) { }

	}

}