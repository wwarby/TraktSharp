using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities;

namespace TraktSharp.Tests.Modules {

	[TestClass]
	internal abstract class TraktRequestTestsBase {

		protected TraktRequestTestsBase() {
			FakeResponseHandler = new FakeResponseHandler();
			FakeResponsePath = "";
			FakeResponseCode = HttpStatusCode.OK;
			Client = new TraktClient(FakeResponseHandler) {
				Authentication = {
					CurrentAccessToken = new TraktAccessToken {
						AccessToken = "abcdef",
						AccessTokenExpires = DateTime.Now.AddYears(1)
					}
				}
			};
			Client.BeforeRequest += (sender, e) => FakeResponseHandler.AddFakeResponse(e.Request.RequestUri.AbsoluteUri, FakeResponseCode, FakeResponsePath);
			Client.AfterRequest += (sender, e) => {
				LastRequest = e.Request;
				LastResponse = e.Response;
				LastResponseText = e.ResponseText;
				LastHttpClient = e.Client;
			};
		}

		internal string FakeResponsePath { get; set; }

		internal HttpStatusCode FakeResponseCode { get; set; }

		internal FakeResponseHandler FakeResponseHandler { get; private set; }

		internal TraktClient Client { get; private set; }

		internal HttpRequestMessage LastRequest { get; set; }

		internal HttpResponseMessage LastResponse { get; set; }

		internal string LastResponseText { get; set; }

		internal HttpClient LastHttpClient { get; set; }

	}

}