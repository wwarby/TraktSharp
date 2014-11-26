using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktPersonFactory {

		public static TraktPerson FromId(string id, StringPersonIdType type = StringPersonIdType.Auto) { return FromId<TraktPerson>(id, type); }

		public static T FromId<T>(string id, StringPersonIdType type = StringPersonIdType.Auto) where T : TraktPerson {
			if (string.IsNullOrEmpty(id)) {
				throw new ArgumentException("Id not set", "id");
			}

			if (type == StringPersonIdType.Auto) {
				if (id.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase)) {
					type = StringPersonIdType.Imdb;
				} else {
					throw new ArgumentException("Unable to detect id type", "type");
				}
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (type) {
				case StringPersonIdType.Imdb:
					ret.Ids.Imdb = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static TraktPerson FromId(int id, IntPersonIdType type) { return FromId<TraktPerson>(id, type); }

		public static T FromId<T>(int id, IntPersonIdType type) where T : TraktPerson {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktPersonIds();

			switch (type) {
				case IntPersonIdType.Trakt:
					ret.Ids.Trakt = id;
					break;
				case IntPersonIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				case IntPersonIdType.TvRage:
					ret.Ids.TvRage = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static IEnumerable<TraktPerson> FromIds(IEnumerable<string> ids, StringPersonIdType type = StringPersonIdType.Auto) {
			return ids == null ? null : ids.Select(id => FromId<TraktPerson>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<string> ids, StringPersonIdType type = StringPersonIdType.Auto) where T : TraktPerson {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

		public static IEnumerable<TraktPerson> FromIds(IEnumerable<int> ids, IntPersonIdType type) {
			return ids == null ? null : ids.Select(id => FromId<TraktPerson>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<int> ids, IntPersonIdType type) where T : TraktPerson {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

	}

}