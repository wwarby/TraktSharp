﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities.Response.Genres;
using TraktSharp.Enums;
using TraktSharp.Tests.Request;

namespace TraktSharp.Tests.Modules {

	/// <summary>Unit tests</summary>
	[TestClass]
	public class TraktGenresModuleTests : TraktRequestTestsBase {

		/// <summary>Test</summary>
		[TestMethod]
		public async Task TestGenresGetGenresAsync() {

			FakeResponsePath = @"Genres\Movies.json";
			var moviesResult = (await Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies)).ToList();

			FakeResponsePath = @"Genres\Shows.json";
			var showsResult = (await Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Shows)).ToList();

			moviesResult.Should().BeOfType(typeof(List<TraktGenresListResponseItem>));
			moviesResult.First().Name.Should().Be("Action");
			moviesResult.First().Slug.Should().Be("action");
			moviesResult.Should().HaveCount(32);

			showsResult.Should().BeOfType(typeof(List<TraktGenresListResponseItem>));
			showsResult.Skip(3).First().Name.Should().Be("Biography");
			showsResult.Skip(3).First().Slug.Should().Be("biography");
			showsResult.Should().HaveCount(28);
			showsResult.Should().NotBeEquivalentTo(moviesResult);

		}

	}

}