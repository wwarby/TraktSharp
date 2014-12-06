using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities.Response.Auth;

namespace TraktSharp.Tests.Modules {

	[TestClass]
	internal class TraktAuthModuleTests : TraktRequestTestsBase {

		[TestMethod]
		internal async Task TestLoginAsync() {

			FakeResponsePath = @"Auth\Login.json";
			var result = await Client.Auth.LoginAsync("foo", "bar");

			result.Should().BeOfType(typeof(TraktAuthLoginResponse));
			result.Token.Should().Be("98ausd98SAUD98kzxjl");

		}

		[TestMethod]
		internal async Task TestLogoutAsync() {

			await Client.Auth.LogoutAsync();

		}

	}

}