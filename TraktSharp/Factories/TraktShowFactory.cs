using System;
using System.Collections.Generic;
using System.Linq;
using TraktSharp.Entities;
using TraktSharp.Enums;

namespace TraktSharp.Factories {

	/// <summary>A factory for generating <see cref="TraktShow"/> instances</summary>
	public static class TraktShowFactory {

		/// <summary>Create an instance of <see cref="TraktShow"/> from an ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static TraktShow FromId(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) { return FromId<TraktShow>(showId, showIdType); }

		/// <summary>Create an instance of a <see cref="TraktShow"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(string showId, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) where T : TraktShow {
			if (string.IsNullOrEmpty(showId)) {
				throw new ArgumentException("showId not set", "showId");
			}

			if (showIdType == TraktTextShowIdType.Auto) {
				showIdType = showId.StartsWith("tt", StringComparison.InvariantCultureIgnoreCase) ? TraktTextShowIdType.Imdb : TraktTextShowIdType.Slug;
			}

			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktShowIds();

			switch (showIdType) {
				case TraktTextShowIdType.Slug:
					ret.Ids.Slug = showId;
					break;
				case TraktTextShowIdType.Imdb:
					ret.Ids.Imdb = showId;
					break;
				default:
					throw new ArgumentOutOfRangeException("showIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktShow"/> from an ID</summary>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static TraktShow FromId(int showId, TraktNumericShowIdType showIdType) { return FromId<TraktShow>(showId, showIdType); }

		/// <summary>Create an instance of a <see cref="TraktShow"/> subclass from an ID</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="showId">The show ID</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static T FromId<T>(int showId, TraktNumericShowIdType showIdType) where T : TraktShow {
			var ret = Activator.CreateInstance<T>();
			ret.Ids = new TraktShowIds();

			switch (showIdType) {
				case TraktNumericShowIdType.Trakt:
					ret.Ids.Trakt = showId;
					break;
				case TraktNumericShowIdType.Tvdb:
					ret.Ids.Tvdb = showId;
					break;
				case TraktNumericShowIdType.Tmdb:
					ret.Ids.Tmdb = showId;
					break;
				case TraktNumericShowIdType.TvRage:
					ret.Ids.TvRage = showId;
					break;
				default:
					throw new ArgumentOutOfRangeException("showIdType");
			}

			return ret;
		}

		/// <summary>Create an instance of <see cref="TraktShow"/> from a title and year</summary>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <returns>See summary</returns>
		public static TraktShow FromTitleAndYear(string showTitle, int? showYear = null) { return FromTitleAndYear<TraktShow>(showTitle, showYear); }

		/// <summary>Create an instance of a <see cref="TraktShow"/> subclass from a title and year</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="showTitle">The show title</param>
		/// <param name="showYear">The show release year (first season)</param>
		/// <returns>See summary</returns>
		public static T FromTitleAndYear<T>(string showTitle, int? showYear = null) where T : TraktShow {
			if (string.IsNullOrEmpty(showTitle)) {
				throw new ArgumentException("showTitle not set", "showTitle");
			}
			var ret = Activator.CreateInstance<T>();
			ret.Title = showTitle;
			ret.Year = showYear;
			return ret;
		}

		/// <summary>Create an collection of <see cref="TraktShow"/> instances from a collecion of IDs</summary>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktShow> FromIds(IEnumerable<string> showIds, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) {
			return showIds == null ? null : showIds.Select(showId => FromId<TraktShow>(showId, showIdType));
		}

		/// <summary>Create an collection of <see cref="TraktShow"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<string> showIds, TraktTextShowIdType showIdType = TraktTextShowIdType.Auto) where T : TraktShow {
			return showIds == null ? null : showIds.Select(showId => FromId<T>(showId, showIdType));
		}

		/// <summary>Create an collection of <see cref="TraktShow"/> instances from a collecion of IDs</summary>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<TraktShow> FromIds(IEnumerable<int> showIds, TraktNumericShowIdType showIdType) {
			return showIds == null ? null : showIds.Select(showId => FromId<TraktShow>(showId, showIdType));
		}

		/// <summary>Create an collection of <see cref="TraktShow"/> subclass instances from a collecion of IDs</summary>
		/// <typeparam name="T">A subclass of <see cref="TraktMovie"/> to be created</typeparam>
		/// <param name="showIds">A collection of show IDs</param>
		/// <param name="showIdType">The show ID type</param>
		/// <returns>See summary</returns>
		public static IEnumerable<T> FromIds<T>(IEnumerable<int> showIds, TraktNumericShowIdType showIdType) where T : TraktShow {
			return showIds == null ? null : showIds.Select(showId => FromId<T>(showId, showIdType));
		}

	}

}