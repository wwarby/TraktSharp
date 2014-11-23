using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktShowFactory {

		public static TraktShow FromId(string id, StringShowIdType type = StringShowIdType.Auto) { return FromId<TraktShow>(id, type); }

		public static T FromId<T>(string id, StringShowIdType type = StringShowIdType.Auto) where T : TraktShow {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringShowIdType.Auto) {
				type = id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase) ? StringShowIdType.Imdb : StringShowIdType.Slug;
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktShowIds();

			switch (type) {
				case StringShowIdType.Slug:
					ret.Ids.Slug = id;
					break;
				case StringShowIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktShow FromId(int id, IntShowIdType type) { return FromId<TraktShow>(id, type); }

		public static T FromId<T>(int id, IntShowIdType type) where T : TraktShow {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktShowIds();

			switch (type) {
				case IntShowIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntShowIdType.Tvdb:
					ret.Ids.Tvdb = id;
					break;
				case IntShowIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				case IntShowIdType.TvRage:
					ret.Ids.TvRage = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktShow FromTitleAndYear(string title, int? year = null) { return FromTitleAndYear<TraktShow>(title, year); }

		public static T FromTitleAndYear<T>(string title, int? year = null) where T : TraktShow {
			if (string.IsNullOrEmpty(title)) {
				throw new ArgumentException("Title not set", "title");
			}
			var ret = Activator.CreateInstance<T>();
			ret.Title = title;
			ret.Year = year;
			return ret;
		}

		public static IEnumerable<TraktShow> FromIds(IEnumerable<string> ids, StringShowIdType type = StringShowIdType.Auto) {
			return ids == null ? null : ids.Select(id => FromId<TraktShow>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<string> ids, StringShowIdType type = StringShowIdType.Auto) where T : TraktShow {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

		public static IEnumerable<TraktShow> FromIds(IEnumerable<int> ids, IntShowIdType type) {
			return ids == null ? null : ids.Select(id => FromId<TraktShow>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<int> ids, IntShowIdType type) where T : TraktShow {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

	}

}