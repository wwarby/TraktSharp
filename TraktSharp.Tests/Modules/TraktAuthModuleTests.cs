using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities.Response.Auth;
using TraktSharp.Tests.Request;

namespace TraktSharp.Tests.Modules {

	/// <summary>Unit tests</summary>
	[TestClass]
	public class TraktAuthModuleTests : TraktRequestTestsBase {

		/// <summary>Test</summary>
		[TestMethod]
		public async Task TestLoginAsync() {

			FakeResponsePath = @"Auth\Login.json";
			var result = await Client.Auth.LoginAsync("foo", "bar");

			result.Should().BeOfType(typeof(TraktAuthLoginResponse));
			result.Token.Should().Be("98ausd98SAUD98kzxjl");

		}

		/// <summary>Test</summary>
		[TestMethod]
		public async Task TestLogoutAsync() {

			await Client.Auth.LogoutAsync();

		}

	}

}