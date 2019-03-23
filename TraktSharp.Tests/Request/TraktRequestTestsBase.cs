using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities;
using TraktSharp.Enums;
// ReSharper disable StringLiteralTypo

namespace TraktSharp.Tests.Request {

	/// <summary>Abstract base class for unit test classes that generate Trakt API requests</summary>
	[TestClass]
	public abstract class TraktRequestTestsBase {

		/// <summary>Default constructor for the class</summary>
		protected TraktRequestTestsBase() {
			FakeResponseHandler = new FakeResponseHandler();
			FakeResponsePath = string.Empty;
			FakeResponseCode = HttpStatusCode.OK;
			Client = new TraktClient(FakeResponseHandler) {
				Authentication = {
					CurrentOAuthAccessToken = new TraktOAuthAccessToken {
						AccessToken = "abcdef",
						AccessTokenExpires = DateTime.Now.AddYears(1)
					},
					CurrentSimpleAccessToken = "qwerty",
					Username = "alice",
					LoginUsernameOrEmail = "bob",
					AuthenticationMode = TraktAuthenticationMode.OAuth
				}
			};
			Client.BeforeRequest += (sender, e) => FakeResponseHandler.AddFakeResponse(e.Request.RequestUri.AbsoluteUri, FakeResponseCode, FakeResponsePath);
			Client.AfterRequest += (sender, e) => {
				LastRequest = e.Request;
				LastResponse = e.Response;
				LastResponseText = e.ResponseText;
			};
		}

		/// <summary>A path to the file containing the fake response text</summary>
		protected string FakeResponsePath { get; set; }

		/// <summary>The fake HTTP status code to send in the response</summary>
		protected HttpStatusCode FakeResponseCode { get; set; }

		/// <summary>The fake response handler</summary>
		protected FakeResponseHandler FakeResponseHandler { get; private set; }

		/// <summary>The client</summary>
		protected TraktClient Client { get; private set; }

		/// <summary>The most recently sent HTTP request</summary>
		protected HttpRequestMessage LastRequest { get; set; }

		/// <summary>The most recently received HTTP response</summary>
		protected HttpResponseMessage LastResponse { get; set; }

		/// <summary>The most recently received HTTP response text</summary>
		protected string LastResponseText { get; set; }

	}

}