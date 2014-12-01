using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities;
using TraktSharp.Entities.Response.Checkin;
using TraktSharp.Enums;
using TraktSharp.Exceptions;
using TraktSharp.Factories;

namespace TraktSharp.Tests.Modules {

	[TestClass]
	public class TraktCheckinModuleTests : TraktRequestTestsBase {

		[TestMethod]
		public async Task TestCheckinCheckinMovieAsync() {

			FakeResponsePath = @"Checkin\Movie.json";

			((Action)(() => Client.Checkin.CheckinMovieAsync(string.Empty, StringMovieIdType.Auto).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(string.Empty, StringMovieIdType.Imdb).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(string.Empty, StringMovieIdType.Slug).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(0, IntMovieIdType.Trakt).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(0, IntMovieIdType.Tmdb).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(string.Empty, 1).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync("foobar", null).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(null).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinMovieAsync(new TraktMovie()).Wait())).ShouldThrow<ArgumentException>();

			((Action)(() => Client.Checkin.CheckinMovieAsync("foobar", StringMovieIdType.Auto).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync("foobar", StringMovieIdType.Imdb).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync("foobar", StringMovieIdType.Slug).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync(1, IntMovieIdType.Trakt).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync(1, IntMovieIdType.Tmdb).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync("foobar", 1).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinMovieAsync(TraktMovieFactory.FromId("foobar")).Wait())).ShouldNotThrow();

			var result = await Client.Checkin.CheckinMovieAsync(
				TraktMovieFactory.FromId("foobar"),
				new TraktSharing { Facebook = true, Tumblr = true, Twitter = true },
				"foobar",
				"foobar",
				"foobar",
				"foobar",
				DateTime.Now,
				ExtendedOption.FullAndImages);

			result.Should().BeOfType(typeof(TraktCheckinMovieResponse));
			result.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z", null, DateTimeStyles.RoundtripKind));
			result.Sharing.Facebook.Should().BeTrue();
			result.Sharing.Twitter.Should().BeTrue();
			result.Sharing.Tumblr.Should().BeFalse();
			result.Movie.Title.Should().Be("Guardians of the Galaxy");
			result.Movie.Year.Should().Be(2014);
			result.Movie.Ids.Trakt.Should().Be(28);
			result.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
			result.Movie.Ids.Imdb.Should().Be("tt2015381");
			result.Movie.Ids.Tmdb.Should().Be(118340);
			result.Movie.Rating.Should().NotHaveValue();

			FakeResponsePath = @"Checkin\Error.409.json";
			FakeResponseCode = HttpStatusCode.Conflict;
			var ex = ((Action) (() => Client.Checkin.CheckinMovieAsync("foobar", StringMovieIdType.Auto).Wait())).ShouldThrow<TraktConflictException>().Which;
			ex.ExpiresAt.Should().Be(DateTime.Parse("2014-10-15T22:21:29.000Z", null, DateTimeStyles.RoundtripKind));
			ex.StatusCode.Should().Be(FakeResponseCode);
			ex.TraktErrorType.Should().BeNull();

		}

		[TestMethod]
		public async Task TestCheckinCheckinEpisodeAsync() {

			FakeResponsePath = @"Checkin\Episode.json";
			
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(string.Empty, StringEpisodeIdType.Auto).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(string.Empty, StringEpisodeIdType.Imdb).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("foobar", StringEpisodeIdType.Auto).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(0, IntEpisodeIdType.Trakt).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(0, IntEpisodeIdType.Tmdb).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(0, IntEpisodeIdType.Tvdb).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(0, IntEpisodeIdType.TvRage).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(string.Empty, 1, 1, 1).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", 1, 0, 1).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", 1, 1, 0).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(null).Wait())).ShouldThrow<ArgumentException>();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(new TraktEpisode()).Wait())).ShouldThrow<ArgumentException>();

			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", StringEpisodeIdType.Auto).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", StringEpisodeIdType.Imdb).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(1, IntEpisodeIdType.Trakt).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(1, IntEpisodeIdType.Tmdb).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(1, IntEpisodeIdType.Tvdb).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(1, IntEpisodeIdType.TvRage).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", 1, 1, 1).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", 0, 1, 1).Wait())).ShouldNotThrow();
			((Action)(() => Client.Checkin.CheckinEpisodeAsync(TraktEpisodeFactory.FromId("ttfoobar")).Wait())).ShouldNotThrow();

			var result = await Client.Checkin.CheckinEpisodeAsync(
				TraktEpisodeFactory.FromId("ttfoobar"),
				TraktShowFactory.FromId("ttfoobar"),
				new TraktSharing { Facebook = true, Tumblr = true, Twitter = true },
				"foobar",
				"foobar",
				"foobar",
				"foobar",
				DateTime.Now,
				ExtendedOption.FullAndImages);

			result.Should().BeOfType(typeof(TraktCheckinEpisodeResponse));
			result.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z", null, DateTimeStyles.RoundtripKind));
			result.Sharing.Facebook.Should().BeTrue();
			result.Sharing.Twitter.Should().BeTrue();
			result.Sharing.Tumblr.Should().BeFalse();
			result.Episode.SeasonNumber.Should().Be(1);
			result.Episode.EpisodeNumber.Should().Be(1);
			result.Episode.Title.Should().Be("Pilot");
			result.Episode.Ids.Trakt.Should().Be(16);
			result.Episode.Ids.Tvdb.Should().Be(349232);
			result.Episode.Ids.Imdb.Should().Be("tt0959621");
			result.Episode.Ids.Tmdb.Should().Be(62085);
			result.Episode.Ids.TvRage.Should().Be(637041);
			result.Episode.Rating.Should().NotHaveValue();
			result.Show.Title.Should().Be("Breaking Bad");
			result.Show.Year.Should().Be(2008);
			result.Show.Ids.Trakt.Should().Be(1);
			result.Show.Ids.Slug.Should().Be("breaking-bad");
			result.Show.Ids.Tvdb.Should().Be(81189);
			result.Show.Ids.Imdb.Should().Be("tt0903747");
			result.Show.Ids.Tmdb.Should().Be(1396);
			result.Show.Ids.TvRage.Should().Be(18164);
			result.Show.Rating.Should().NotHaveValue();

			FakeResponsePath = @"Checkin\Error.409.json";
			FakeResponseCode = HttpStatusCode.Conflict;
			var ex = ((Action)(() => Client.Checkin.CheckinEpisodeAsync("ttfoobar", StringEpisodeIdType.Auto).Wait())).ShouldThrow<TraktConflictException>().Which;
			ex.ExpiresAt.Should().Be(DateTime.Parse("2014-10-15T22:21:29.000Z", null, DateTimeStyles.RoundtripKind));
			ex.StatusCode.Should().Be(FakeResponseCode);
			ex.TraktErrorType.Should().BeNull();

		}

	}

}