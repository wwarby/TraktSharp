using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktEpisodeFactory {

		public static TraktEpisode FromId(string id, StringEpisodeIdType type = StringEpisodeIdType.Auto) { return FromId<TraktEpisode>(id, type); }

		public static T FromId<T>(string id, StringEpisodeIdType type = StringEpisodeIdType.Auto) where T : TraktEpisode {
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

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktEpisodeIds();

			switch (type) {
				case StringEpisodeIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktEpisode FromId(int id, IntEpisodeIdType type) { return FromId<TraktEpisode>(id, type); }

		public static T FromId<T>(int id, IntEpisodeIdType type) where T : TraktEpisode {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktEpisodeIds();

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

		public static TraktEpisode FromSeasonAndNumber(int season, int number) { return FromSeasonAndNumber<TraktEpisode>(season, number); }

		public static T FromSeasonAndNumber<T>(int season, int number) where T : TraktEpisode {
			var ret = Activator.CreateInstance<T>();
			ret.Season = season;
			ret.Number = number;
			return ret;
		}

		public static IEnumerable<TraktEpisode> FromIds(IEnumerable<string> ids, StringEpisodeIdType type = StringEpisodeIdType.Auto) {
			return ids == null ? null : ids.Select(id => FromId<TraktEpisode>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<string> ids, StringEpisodeIdType type = StringEpisodeIdType.Auto) where T : TraktEpisode {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

		public static IEnumerable<TraktEpisode> FromIds(IEnumerable<int> ids, IntEpisodeIdType type) {
			return ids == null ? null : ids.Select(id => FromId<TraktEpisode>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<int> ids, IntEpisodeIdType type) where T : TraktEpisode {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

		public static IEnumerable<TraktEpisode> FromSeasonAndNumbers(int season, IEnumerable<int> numbers) {
			return numbers == null ? null : numbers.Select(number => FromSeasonAndNumber<TraktEpisode>(season, number));
		}

		public static IEnumerable<T> FromSeasonAndNumbers<T>(int season, IEnumerable<int> numbers) where T : TraktEpisode {
			return numbers == null ? null : numbers.Select(number => FromSeasonAndNumber<T>(season, number));
		}

	}

}