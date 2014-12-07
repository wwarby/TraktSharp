using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TraktSharp.Entities.Response.Calendars;
using TraktSharp.Tests.Request;

namespace TraktSharp.Tests.Modules {

	[TestClass]
	public class TraktCalendarsModuleTests : TraktRequestTestsBase {

		[TestMethod]
		public async Task TestCalendarsGetMoviesAsync() {

			FakeResponsePath = @"Calendars\Shows.json";
			var result = await Client.Calendars.GetShowsAsync();

			result.Should().BeOfType(typeof(TraktCalendarsShowsResponse));
			result.Should().HaveCount(2);
			result.First().Key.Should().Be("2014-07-14");
			result.First().Value.First().AirsAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z", null, DateTimeStyles.RoundtripKind));
			result.First().Value.First().Episode.SeasonNumber.Should().Be(7);
			result.First().Value.First().Episode.EpisodeNumber.Should().Be(4);
			result.First().Value.First().Episode.Title.Should().Be("Death is Not the End");
			result.First().Value.First().Episode.Ids.Trakt.Should().Be(443);
			result.First().Value.First().Episode.Ids.Tvdb.Should().Be(4851180);
			result.First().Value.First().Episode.Ids.Imdb.Should().Be("tt3500614");
			result.First().Value.First().Episode.Ids.Tmdb.Should().Be(988123);
			result.First().Value.First().Episode.Ids.TvRage.Should().NotHaveValue();
			result.First().Value.First().Episode.Rating.Should().NotHaveValue();

		}

		[TestMethod]
		public async Task TestCalendarsGetNewShowsAsync() {

			FakeResponsePath = @"Calendars\ShowsNew.json";
			var result = await Client.Calendars.GetShowsAsync();

			result.Should().BeOfType(typeof(TraktCalendarsShowsResponse));
			result.Should().HaveCount(1);
			result.First().Key.Should().Be("2014-06-30");
			result.First().Value.First().AirsAt.Should().Be(DateTime.Parse("2014-06-30T02:00:00.000Z", null, DateTimeStyles.RoundtripKind));
			result.First().Value.First().Episode.SeasonNumber.Should().Be(1);
			result.First().Value.First().Episode.EpisodeNumber.Should().Be(1);
			result.First().Value.First().Episode.Title.Should().Be("Pilot");
			result.First().Value.First().Episode.Ids.Trakt.Should().Be(497);
			result.First().Value.First().Episode.Ids.Tvdb.Should().NotHaveValue();
			result.First().Value.First().Episode.Ids.Imdb.Should().Be("tt3203968");
			result.First().Value.First().Episode.Ids.Tmdb.Should().Be(983732);
			result.First().Value.First().Episode.Ids.TvRage.Should().NotHaveValue();
			result.First().Value.First().Episode.Rating.Should().NotHaveValue();

		}

		[TestMethod]
		public async Task TestCalendarsGetPremiereShowsAsync() {

			FakeResponsePath = @"Calendars\ShowsPremieres.json";
			var result = await Client.Calendars.GetShowsAsync();

			result.Should().BeOfType(typeof(TraktCalendarsShowsResponse));
			result.Should().HaveCount(2);
			result.First().Key.Should().Be("2014-06-30");
			result.First().Value.First().AirsAt.Should().Be(DateTime.Parse("2014-06-30T02:00:00.000Z", null, DateTimeStyles.RoundtripKind));
			result.First().Value.First().Episode.SeasonNumber.Should().Be(1);
			result.First().Value.First().Episode.EpisodeNumber.Should().Be(1);
			result.First().Value.First().Episode.Title.Should().Be("Pilot");
			result.First().Value.First().Episode.Ids.Trakt.Should().Be(497);
			result.First().Value.First().Episode.Ids.Tvdb.Should().NotHaveValue();
			result.First().Value.First().Episode.Ids.Imdb.Should().Be("tt3203968");
			result.First().Value.First().Episode.Ids.Tmdb.Should().Be(983732);
			result.First().Value.First().Episode.Ids.TvRage.Should().NotHaveValue();
			result.First().Value.First().Episode.Rating.Should().NotHaveValue();

		}

		[TestMethod]
		public async Task TestCalendarsGetShowsAsync() {

			FakeResponsePath = @"Calendars\Movies.json";
			var result = await Client.Calendars.GetMoviesAsync();

			result.Should().BeOfType(typeof(TraktCalendarsMoviesResponse));
			result.Should().HaveCount(2);
			result.First().Key.Should().Be("2014-08-01");
			result.First().Value.First().Movie.Title.Should().Be("Guardians of the Galaxy");
			result.First().Value.First().Movie.Year.Should().Be(2014);
			result.First().Value.First().Movie.Ids.Trakt.Should().Be(28);
			result.First().Value.First().Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
			result.First().Value.First().Movie.Ids.Imdb.Should().Be("tt2015381");
			result.First().Value.First().Movie.Ids.Tmdb.Should().Be(118340);
			result.First().Value.First().Movie.Rating.Should().NotHaveValue();

		}

	}

}