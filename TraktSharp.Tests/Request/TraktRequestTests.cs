using System;
using System.Linq;
using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Enums;
using TraktSharp.Exceptions;

namespace TraktSharp.Tests.Request {

	/// <summary>Unit tests</summary>
	[TestClass]
	public class TraktRequestTests : TraktRequestTestsBase {

		/// <summary>Test</summary>
		[TestMethod]
		public void TestResponseCodeExceptions() {

			FakeResponsePath = @"Genres\Movies.json";

			FakeResponseCode = HttpStatusCode.OK;
			((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldNotThrow();

			FakeResponseCode = HttpStatusCode.Created;
			((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldNotThrow();

			FakeResponseCode = HttpStatusCode.NoContent;
			((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldNotThrow();

			FakeResponseCode = HttpStatusCode.BadRequest;
			var exBadRequest = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktBadRequestException>().Which;
			exBadRequest.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.Unauthorized;
			var exUnauthorized = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktUnauthorizedException>().Which;
			exUnauthorized.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.Forbidden;
			var exForbidden = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktForbiddenException>().Which;
			exForbidden.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.NotFound;
			var exNotFound = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktNotFoundException>().Which;
			exNotFound.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.MethodNotAllowed;
			var exMethodNotFound = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktMethodNotFoundException>().Which;
			exMethodNotFound.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.Conflict;
			var exConflict = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktConflictException>().Which;
			exConflict.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = (HttpStatusCode)422;
			var exUnprocessableEntity = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktUnprocessableEntityException>().Which;
			exUnprocessableEntity.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = (HttpStatusCode)429;
			var ex429 = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktRateLimitExceededException>().Which;
			ex429.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.InternalServerError;
			var exServerError = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktServerErrorException>().Which;
			exServerError.StatusCode.Should().Be(FakeResponseCode);

			FakeResponseCode = HttpStatusCode.ServiceUnavailable;
			var exServiceUnavailable = ((Action)(() => Client.Genres.GetGenresAsync(TraktGenreTypeOptions.Movies).Wait())).ShouldThrow<TraktServiceUnavailableException>().Which;
			exServiceUnavailable.StatusCode.Should().Be(FakeResponseCode);

		}

	}

}