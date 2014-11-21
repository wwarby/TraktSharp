using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Request.Genres;

namespace TraktSharp.Tests.Request.Genres {

	[TestClass]
	public class TraktGenresListRequestTests : TraktRequestTestsBase {

		[TestMethod]
		public async Task TestTraktGenresListRequest() {

			var request = new TraktGenresListRequest(Client);
			FakeResponseHandler.AddFakeResponse(request.Url, HttpStatusCode.OK, @"Genres\List.json");
			
			var showsResult = (await request.SendAsync()).ToList();
			request.Type = GenreTypeOptions.Shows;

			var moviesResult = (await request.SendAsync()).ToList();
			request.Type = GenreTypeOptions.Movies;

			showsResult.Should().BeOfType(typeof(List<TraktGenresListResponseItem>));
			showsResult.Should().HaveCount(32);
			showsResult.First().Name.Should().Be("action");
			showsResult.First().Slug.Should().Be("action");

			moviesResult.Should().BeOfType(typeof(List<TraktGenresListResponseItem>));
			moviesResult.ShouldBeEquivalentTo(showsResult);

		}

	}

}