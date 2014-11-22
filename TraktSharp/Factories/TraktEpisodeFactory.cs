using System;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktEpisodeFactory {

		public static TraktEpisode FromId(string id, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringEpisodeIdType.Auto) {
				if (id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase)) {
					type = StringEpisodeIdType.Imdb;
				} else {
					throw new ArgumentException("Unable to detect id type", "type");
				}
			}

			var ret = new TraktEpisode { Ids = new TraktEpisodeIds() };

			switch (type) {
				case StringEpisodeIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktEpisode FromId(int id, IntEpisodeIdType type) {
			var ret = new TraktEpisode { Ids = new TraktEpisodeIds() };

			switch (type) {
				case IntEpisodeIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntEpisodeIdType.Tvdb:
					ret.Ids.Tvdb = id;
					break;
				case IntEpisodeIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				case IntEpisodeIdType.TvRage:
					ret.Ids.TvRage = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktEpisode FromSeasonAndNumber(int season, int number) { return new TraktEpisode {Season = season, Number = number}; }

	}

}