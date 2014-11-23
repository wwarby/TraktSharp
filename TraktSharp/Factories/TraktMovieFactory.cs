using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktMovieFactory {

		public static TraktMovie FromId(string id, StringMovieIdType type = StringMovieIdType.Auto) { return FromId<TraktMovie>(id, type); }

		public static T FromId<T>(string id, StringMovieIdType type = StringMovieIdType.Auto) where T : TraktMovie {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringMovieIdType.Auto) {
				type = id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase) ? StringMovieIdType.Imdb : StringMovieIdType.Slug;
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktMovieIds();

			switch (type) {
				case StringMovieIdType.Slug:
					ret.Ids.Slug = id;
					break;
				case StringMovieIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktMovie FromId(int id, IntMovieIdType type) { return FromId<TraktMovie>(id, type); }

		public static T FromId<T>(int id, IntMovieIdType type) where T : TraktMovie {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktMovieIds();

			switch (type) {
				case IntMovieIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntMovieIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktMovie FromTitleAndYear(string title, int? year = null) { return FromTitleAndYear<TraktMovie>(title, year); }

		public static T FromTitleAndYear<T>(string title, int? year = null) where T : TraktMovie {
			if (string.IsNullOrEmpty(title)) {
				throw new ArgumentException("Title not set", "title");
			}
			var ret = Activator.CreateInstance<T>();
			ret.Title = title;
			ret.Year = year;
			return ret;
		}

		public static IEnumerable<TraktMovie> FromIds(IEnumerable<string> ids, StringMovieIdType type = StringMovieIdType.Auto) {
			return ids == null ? null : ids.Select(id => FromId<TraktMovie>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<string> ids, StringMovieIdType type = StringMovieIdType.Auto) where T : TraktMovie {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

		public static IEnumerable<TraktMovie> FromIds(IEnumerable<int> ids, IntMovieIdType type) {
			return ids == null ? null : ids.Select(id => FromId<TraktMovie>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<int> ids, IntMovieIdType type) where T : TraktMovie {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

	}

}