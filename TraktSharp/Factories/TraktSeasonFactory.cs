using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktSeason"/> instances</summary>
	public static class TraktSeasonFactory {

		/// <summary>Create an instance of <see cref="TraktSeason"/> from an ID</summary>
		/// <param name="seasonId">The season ID</param>
		/// <param name="seasonIdType">The season ID type</param>
		/// <returns>See summary</returns>
		public static TraktSeason FromId(int seasonId, TraktNumericSeasonIdType seasonIdType) { return FromId<TraktSeason>(seasonId, seasonIdType); }

		/// <summary>Create an instance of a <see cref="TraktSeason"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktSeason"/> to be created</typeparam>
		/// <param name="seasonId">The season ID</param>
		/// <param name="seasonIdType">The season ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int seasonId, TraktNumericSeasonIdType seasonIdType) where T : TraktSeason {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktSeasonIds();

			switch (seasonIdType) {
				case TraktNumericSeasonIdType.Tvdb:
					ret.Ids.Tvdb = seasonId;
					break;
				case TraktNumericSeasonIdType.Tmdb:
					ret.Ids.Tmdb = seasonId;
					break;
				case TraktNumericSeasonIdType.TvRage:
					ret.Ids.TvRage = seasonId;
					break;
				default:
					throw new ArgumentOutOfRangeException("seasonIdType");
			}

			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktSeason"/> instances from a collecion of IDs</summary>
		/// <param name="seasonIds">A collection of season IDs</param>
		/// <param name="seasonIdType">The season ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktSeason> FromIds(IEnumerable<int> seasonIds, TraktNumericSeasonIdType seasonIdType) {
			return seasonIds == null ? null : seasonIds.Select(seasonId => FromId<TraktSeason>(seasonId, seasonIdType));
		}

		/// <summary>Create an collection of <see cref="TraktSeason"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktSeason"/> to be created</typeparam>
		/// <param name="seasonIds">A collection of season IDs</param>
		/// <param name="seasonIdType">The season ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> seasonIds, TraktNumericSeasonIdType seasonIdType) where T : TraktSeason {
			return seasonIds == null ? null : seasonIds.Select(seasonId => FromId<T>(seasonId, seasonIdType));
		}

	}

}