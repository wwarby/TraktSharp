using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities;

namespace TraktSharp.Tests.Request {

	[TestClass]
	public abstract class TraktRequestTestsBase {

		protected TraktRequestTestsBase() {
			FakeResponseHandler = new FakeResponseHandler();
			Client = new TraktClient(FakeResponseHandler) {
				Authentication = {
					CurrentAccessToken = new TraktAccessToken {
						AccessToken = "abcdef",
						AccessTokenExpires = DateTime.Now.AddYears(1)
					}
				}
			};
		}

		public FakeResponseHandler FakeResponseHandler { get; private set; }

		public TraktClient Client { get; private set; }

	}

}