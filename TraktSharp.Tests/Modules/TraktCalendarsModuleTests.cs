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
	public class TraktCalendarsShowsRequestTests : TraktRequestTestsBase {

		[TestMethod]
		public async Task TestCalendarsGetShowsAsync() {

			FakeResponsePath = @"Calendars\Shows.json";
			var result = await Client.Calendars.GetShowsAsync();

			result.Should().BeOfType(typeof(TraktCalendarsShowsResponse));
			result.Should().HaveCount(2);
			result.First().Key.Should().Be("2014-07-14");
			result.First().Value.First().AirsAt.Should().Be(DateTime.Parse("2014-07-14T01:00:00.000Z", null, DateTimeStyles.RoundtripKind));
			result.First().Value.First().Episode.Season.Should().Be(7);
			result.First().Value.First().Episode.Number.Should().Be(4);
			result.First().Value.First().Episode.Title.Should().Be("Death is Not the End");
			result.First().Value.First().Episode.Ids.Trakt.Should().Be(443);
			result.First().Value.First().Episode.Ids.Tvdb.Should().Be(4851180);
			result.First().Value.First().Episode.Ids.Imdb.Should().Be("tt3500614");
			result.First().Value.First().Episode.Ids.Tmdb.Should().Be(988123);
			result.First().Value.First().Episode.Ids.TvRage.Should().NotHaveValue();
			result.First().Value.First().Episode.Rating.Should().NotHaveValue();

		}

	}

}