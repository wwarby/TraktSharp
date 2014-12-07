using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities;

namespace TraktSharp.Tests.Request {

	[TestClass]
	public abstract class TraktRequestTestsBase {

		protected TraktRequestTestsBase() {
			FakeResponseHandler = new FakeResponseHandler();
			FakeResponsePath = "";
			FakeResponseCode = HttpStatusCode.OK;
			Client = new TraktClient(FakeResponseHandler) {
				Authentication = {
					CurrentOAuthAccessToken = new TraktOAuthAccessToken {
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

		public string FakeResponsePath { get; set; }

		public HttpStatusCode FakeResponseCode { get; set; }

		public FakeResponseHandler FakeResponseHandler { get; private set; }

		public TraktClient Client { get; private set; }

		public HttpRequestMessage LastRequest { get; set; }

		public HttpResponseMessage LastResponse { get; set; }

		public string LastResponseText { get; set; }

		public HttpClient LastHttpClient { get; set; }

	}

}