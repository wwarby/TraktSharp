using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;

namespace TraktSharp.Factories {

	public static class TraktSeasonFactory {

		public static TraktSeason FromId(int id, IntSeasonIdType type) { return FromId<TraktSeason>(id, type); }

		public static T FromId<T>(int id, IntSeasonIdType type) where T : TraktSeason {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktSeasonIds();

			switch (type) {
				case IntSeasonIdType.Tvdb:
					ret.Ids.Tvdb = id;
					break;
				case IntSeasonIdType.Tmdb:
					ret.Ids.Tmdb = id;
					break;
				case IntSeasonIdType.TvRage:
					ret.Ids.TvRage = id;
					break;
				default:
					throw new ArgumentOutOfRangeException("type");
			}

			return ret;
		}

		public static IEnumerable<TraktSeason> FromIds(IEnumerable<int> ids, IntSeasonIdType type) {
			return ids == null ? null : ids.Select(id => FromId<TraktSeason>(id, type));
		}

		public static IEnumerable<T> FromIds<T>(IEnumerable<int> ids, IntSeasonIdType type) where T : TraktSeason {
			return ids == null ? null : ids.Select(id => FromId<T>(id, type));
		}

	}

}